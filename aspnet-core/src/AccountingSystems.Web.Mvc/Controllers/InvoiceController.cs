using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.UI;
using AccountingSystems.Controllers;
using AccountingSystems.Customers;
using AccountingSystems.Invoices;
using AccountingSystems.Invoices.Dto;
using AccountingSystems.Products;
using AccountingSystems.Sessions;
using AccountingSystems.Stocks;
using AccountingSystems.Stocks.Dto;
using AccountingSystems.Web.Models.Invoice;
using AccountingSystems.Web.Models.Transaction;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Mvc.Controllers
{
    [AbpMvcAuthorize]
    public class InvoiceController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly ICustomerAppService _customerService;
        private readonly IProductAppService _productService;
        private readonly IInvoiceAppService _invoiceAppService;
        private readonly IInvoiceDetailsAppService _invoiceDetailsAppService;
        private readonly IStockAppService _stockService;

        public InvoiceController(ISessionAppService sessionAppService,
                                 ICustomerAppService customerService,
                                 IProductAppService productService,
                                 IInvoiceAppService invoiceAppService,
                                 IInvoiceDetailsAppService invoiceDetailsAppService,
                                 IStockAppService stockService
                                 )
        {
            _sessionAppService = sessionAppService;
            _customerService = customerService;
            _productService = productService;
            _invoiceAppService = invoiceAppService;
            _invoiceDetailsAppService = invoiceDetailsAppService;
            _stockService = stockService;
        }
        public async Task<ActionResult> Index()
        {
            var invoices = (await _invoiceAppService.GetInvoice()).Items;
            var model = new InvoiceListViewModel
            {
                InvoiceHeaders = invoices
            };
            return View(model);
        }
        public async Task<ActionResult> Create()
        {
            var customers = (await _customerService.GetCustomer()).Items;
            var products = (await _productService.GetProduct()).Items;

            var model = new CreateInvoiceViewModel
            {
                Customers = customers,
                Products = products,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),

            };
            return View("Create", model);
        }
        [HttpPost]
        public async Task<ActionResult> CreateInvoice(CreateInvoiceDto dto)
        {
            await _invoiceAppService.CreateAsync(dto);

            foreach(var items in dto.InvoiceDetails)
            {
                var check = await _stockService.CheckIfExist(items.ProductId);
                if(check != null)
                {
                    check.TotalPieces -= items.TotalPieces;
                    check.Amount -= items.Amount;
                    await _stockService.UpdateAsync(check);
                }
               
            }

            return Ok(dto);
        }
        public async Task<ActionResult> View(int invoiceId)
        {
            var model = new ViewInvoiceViewModel
            {
                EditInvoice = await _invoiceAppService.GetInvoiceForEdit(new EntityDto(invoiceId)),
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };
            return View("View", model);
        }
        public async Task<ActionResult> Print(int invoiceId)
        {
            var model = new ViewInvoiceViewModel
            {
                EditInvoice = await _invoiceAppService.GetInvoiceForEdit(new EntityDto(invoiceId)),
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };
            return View("Print", model);
        }

        public async Task<ActionResult> Edit(int invoiceId)
        {
            var model = new EditInvoiceViewModel
            {
                EditInvoice = await _invoiceAppService.GetInvoiceForEdit(new EntityDto(invoiceId)),
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };
            return View("Edit", model);
        }
        [HttpPost]
        public async Task<ActionResult> EditInvoice(InvoiceHeaderDto dto)
        {
            foreach (var dtoItem in dto.InvoiceDetails)
            {
                var check = await _stockService.CheckIfExist(dtoItem.ProductId);
                var old = await _invoiceDetailsAppService.GetDetailsAsync(dtoItem.Id);
                if (old != null)
                {
                    if (dtoItem.TotalPieces > old.TotalPieces)
                    {
                        var change = dtoItem.TotalPieces - old.TotalPieces;
                        var tAmount = dtoItem.PricePerPiece * change;
                        check.TotalPieces -= change;
                        check.Amount -= tAmount;

                        await _stockService.UpdateAsync(check);
                    }
                    else if (dtoItem.TotalPieces < old.TotalPieces)
                    {
                        var change = old.TotalPieces - dtoItem.TotalPieces;
                        var tAmount = dtoItem.PricePerPiece * change;
                        check.TotalPieces += change;
                        check.Amount += tAmount;
                        
                        await _stockService.UpdateAsync(check);
                    }
                }
                else
                {
                    check.TotalPieces -= dtoItem.TotalPieces;
                    check.Amount -= dtoItem.Amount;

                    await _stockService.UpdateAsync(check);
                }
            }
            var updated = await _invoiceAppService.UpdateAsync(dto);
            foreach (var items in dto.InvoiceDetails)
            {
                var getCheck = await _invoiceDetailsAppService.GetAsync(new EntityDto<int>(items.Id));
                if (getCheck == null)
                {
                    var toCreate = new InvoiceDetailDto
                    {
                        InvoiceHeaderId = dto.InvoiceId,
                        ProductId = items.ProductId,
                        Case = items.Case,
                        ProdCase = items.ProdCase,
                        Box = items.Box,
                        ProdPiece = items.ProdPiece,
                        Piece = items.Piece,
                        Gross = items.Gross,
                        Discount = items.Discount,
                        Net = items.Net,
                        TotalProductPrice = items.TotalProductPrice,
                    };
                    await _invoiceDetailsAppService.CreateAsync(toCreate);

                }
                else if (getCheck != null)
                {
                    var toUpdate = new InvoiceDetailDto
                    {
                        Id = items.Id,
                        CreationTime = items.CreationTime,
                        CreatorUserId = items.CreatorUserId,
                        TenantId = items.TenantId,
                        InvoiceHeaderId = items.InvoiceHeaderId,
                        ProductId = items.ProductId,
                        Case = items.Case,
                        ProdCase = items.ProdCase,
                        Box = items.Box,
                        ProdPiece = items.ProdPiece,
                        Piece = items.Piece,
                        Gross = items.Gross,
                        Discount = items.Discount,
                        Net = items.Net,
                        TotalProductPrice = items.TotalProductPrice,
                    };
                    await _invoiceDetailsAppService.UpdateAsync(toUpdate);
                }
            }

            return Ok(updated);
        }

        public async Task<ActionResult> GetLastInvoiceCode()
        {
            var invoice = await _invoiceAppService.GetLastInvoiceCode();
            var model = ObjectMapper.Map<GetLastInvoiceViewModel>(invoice);

            return Ok(model);
        }

        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var header = await _invoiceAppService.GetHeaderToExcel();
            var details = await _invoiceDetailsAppService.GetDetailsToExcel();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Headers");
                var ws2 = excel.Workbook.Worksheets.Add("Details");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;

                ws.Cells["A5"].Value = "Invoice_No";
                ws.Cells["B5"].Value = "Cus_Name";
                ws.Cells["C5"].Value = "Salesman_Code";
                ws.Cells["D5"].Value = "T_Case";
                ws.Cells["E5"].Value = "T_Box";
                ws.Cells["F5"].Value = "T_Pieces";
                ws.Cells["G5"].Value = "T_Amount";
                ws.Cells["H5"].Value = "Terms";
                ws.Cells["I5"].Value = "Date";
                int rowStart = 6;
                foreach (var item in header)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.InvoiceCode;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.CustomerName;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.SalesmanCode;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.TotalCase;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.TotalBox;
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.TotalPiece;
                    ws.Cells[string.Format("G{0}", rowStart)].Value = item.TotalNet;
                    ws.Cells[string.Format("H{0}", rowStart)].Value = item.CustomerTerms;
                    ws.Cells[string.Format("I{0}", rowStart)].Value = item.InvoiceDate;
                    ws.Cells[string.Format("I{0}", rowStart)].Style.Numberformat.Format = "mm/dd/yyyy";

                    rowStart++;
                }

                ws.Cells["A:AZ"].AutoFitColumns();

                ws2.Cells["A1"].Value = currentTenant.Tenant.Name;

                ws2.Cells["A3"].Value = "Trans_No";
                ws2.Cells["B3"].Value = "Prod_Code";
                ws2.Cells["C3"].Value = "Trans_Date";
                ws2.Cells["D3"].Value = "Qty_Case";
                ws2.Cells["E3"].Value = "Qty_Box";
                ws2.Cells["F3"].Value = "Qty_Pieces";
                ws2.Cells["G3"].Value = "Sale_Price";
                ws2.Cells["H3"].Value = "Amount";

                int rowStart1 = 4;
                foreach(var item in details)
                {
                    ws2.Cells[string.Format("A{0}", rowStart1)].Value = item.InvoiceHeaderInvoiceCode;
                    ws2.Cells[string.Format("B{0}", rowStart1)].Value = item.ProductCode;
                    ws2.Cells[string.Format("C{0}", rowStart1)].Value = item.CreationTime;
                    ws2.Cells[string.Format("C{0}", rowStart1)].Style.Numberformat.Format = "mm/dd/yyyy";
                    ws2.Cells[string.Format("D{0}", rowStart1)].Value = item.Case;
                    ws2.Cells[string.Format("E{0}", rowStart1)].Value = item.Box;
                    ws2.Cells[string.Format("F{0}", rowStart1)].Value = item.Piece;
                    ws2.Cells[string.Format("G{0}", rowStart1)].Value = item.TotalProductPrice;
                    ws2.Cells[string.Format("H{0}", rowStart1)].Value = item.Net;

                    rowStart1++;
                }
                ws2.Cells["A:AZ"].AutoFitColumns();

                fileContents = excel.GetAsByteArray();
            }
            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }
            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Invoices.xlsx"
            );
        }
    }
}