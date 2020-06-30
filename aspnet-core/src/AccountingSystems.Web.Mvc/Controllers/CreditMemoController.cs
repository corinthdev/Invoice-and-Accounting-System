using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AccountingSystems.BadStocks;
using AccountingSystems.BadStocks.Dto;
using AccountingSystems.Controllers;
using AccountingSystems.CreditMemos;
using AccountingSystems.CreditMemos.Dto;
using AccountingSystems.Customers;
using AccountingSystems.Invoices;
using AccountingSystems.LocationSites;
using AccountingSystems.Products;
using AccountingSystems.Sessions;
using AccountingSystems.Stocks;
using AccountingSystems.Web.Models.CreditMemo;
using AccountingSystems.Web.Models.Transaction;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Mvc.Controllers
{
    public class CreditMemoController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly ICustomerAppService _customerService;
        private readonly IProductAppService _productService;
        private readonly ICreditMemoAppService _creditMemoAppService;
        private readonly ICreditMemoDetailsAppService _creditMemoDetailsAppService;
        private readonly IStockAppService _stockService;
        private readonly IBadStockAppService _badStockService;
        private readonly IInvoiceAppService _invoiceAppService;
        private readonly ILocationSiteAppService _locationSiteAppService;

        public CreditMemoController(ISessionAppService sessionAppService,
                                    ICustomerAppService customerService, 
                                    IProductAppService productService,
                                    ICreditMemoAppService creditMemoAppService,
                                    ICreditMemoDetailsAppService creditMemoDetailsAppService,
                                    IStockAppService stockService,
                                    IBadStockAppService badStockService,
                                    IInvoiceAppService invoiceAppService,
                                    ILocationSiteAppService locationSiteAppService
                                    )
        {
            _sessionAppService = sessionAppService;
            _customerService = customerService;
            _productService = productService;
            _creditMemoAppService = creditMemoAppService;
            _creditMemoDetailsAppService = creditMemoDetailsAppService;
            _stockService = stockService;
            _badStockService = badStockService;
            _invoiceAppService = invoiceAppService;
            _locationSiteAppService = locationSiteAppService;
        }
        public async Task<ActionResult> Index()
        {
            var creditmemos = (await _creditMemoAppService.GetCreditMemo()).Items;
            var model = new CreditMemoListViewModel
            {
                CreditMemos = creditmemos
            };
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var model = new CreateCreditMemoViewModel
            {
                Invoices = (await _invoiceAppService.GetInvoice()).Items,
                Customers = (await _customerService.GetCustomer()).Items,
                Products = (await _productService.GetProduct()).Items,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
                LocationSites = (await _locationSiteAppService.GetLocationSite()).Items
            };
            return View("Create", model);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCreditMemo(CreateCreditMemoDto dto)
        {
            await _creditMemoAppService.CreateAsync(dto);

            if (dto.CreditMemoMode == "Good")
            {
                foreach (var items in dto.CreditMemoDetails)
                {
                    var check = await _stockService.CheckIfExist(items.ProductId);
                    if (check != null)
                    {
                        check.TotalPieces += items.TotalPieces;
                        check.Amount += items.Amount;
                        await _stockService.UpdateAsync(check);
                    }

                }
            }
            else
            {
                foreach (var items in dto.CreditMemoDetails)
                {
                    var check = await _badStockService.CheckIfExist(items.ProductId);
                    if (check != null)
                    {
                        check.TotalPieces += items.TotalPieces;
                        check.Amount += items.Amount;
                        await _badStockService.UpdateAsync(check);
                    }
                    else
                    {
                        var stocks = new BadStockDto
                        {
                            ProductId = items.ProductId,
                            TotalPieces = items.TotalPieces,
                            PricePerPiece = items.PricePerPiece,
                            Amount = items.Amount
                        };

                        await _badStockService.CreateAsync(stocks);
                    }

                }
            }
            return Ok(dto);
        }
        public async Task<ActionResult> View(int creditMemoId)
        {
            var model = new ViewCreditMemoViewModel
            {
                CreditMemoEdit = await _creditMemoAppService.GetCreditMemoForEdit(new EntityDto(creditMemoId)),
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };
            return View("View", model);
        }
        public async Task<ActionResult> Print(int creditMemoId)
        {
            var model = new ViewCreditMemoViewModel
            {
                CreditMemoEdit = await _creditMemoAppService.GetCreditMemoForEdit(new EntityDto(creditMemoId)),
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };
            return View("Print", model);
        }
        public async Task<ActionResult> Edit(int creditMemoId)
        {
            var creditmemo = await _creditMemoAppService.GetCreditMemoForEdit(new EntityDto(creditMemoId));
            var model = new EditCreditMemoViewModel
            {
                CreditMemoEdit = creditmemo,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
                Invoices = (await _invoiceAppService.GetInvoice()).Items,
                LocationSites = (await _locationSiteAppService.GetLocationSite()).Items
            };
            return View("Edit", model);
        }
        [HttpPost]
        public async Task<ActionResult> EditCreditMemo(CreditMemoHeaderDto dto)
        {
            if(dto.CreditMemoMode == "Good")
            {
                foreach (var dtoItem in dto.CreditMemoDetails)
                {
                    var check = await _stockService.CheckIfExist(dtoItem.ProductId);
                    var old = await _creditMemoDetailsAppService.GetDetailsAsync(dtoItem.Id);
                    if (old != null)
                    {
                        if (dtoItem.TotalPieces > old.TotalPieces)
                        {
                            var change = dtoItem.TotalPieces - old.TotalPieces;
                            var tAmount = dtoItem.PricePerPiece * change;
                            check.TotalPieces += change;
                            check.Amount += tAmount;

                            await _stockService.UpdateAsync(check);
                        }
                        else if (dtoItem.TotalPieces < old.TotalPieces)
                        {
                            var change = old.TotalPieces - dtoItem.TotalPieces;
                            var tAmount = dtoItem.PricePerPiece * change;
                            check.TotalPieces -= change;
                            check.Amount -= tAmount;

                            await _stockService.UpdateAsync(check);
                        }
                    }
                    else
                    {
                        check.TotalPieces += dtoItem.TotalPieces;
                        check.Amount += dtoItem.Amount;

                        await _stockService.UpdateAsync(check);
                    }
                }
                var updateme = await _creditMemoAppService.UpdateAsync(dto);
                foreach (var items in dto.CreditMemoDetails)
                {
                    var getCheck = await _creditMemoDetailsAppService.GetAsync(new EntityDto<int>(items.Id));
                    if (getCheck == null)
                    {
                        var toCreate = new CreditMemoDetailDto
                        {
                            CreditMemoHeaderId = dto.CreditMemoId,
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
                        await _creditMemoDetailsAppService.CreateAsync(toCreate);

                    }
                    else if (getCheck != null)
                    {
                        var toUpdate = new CreditMemoDetailDto
                        {
                            Id = items.Id,
                            CreationTime = items.CreationTime,
                            CreatorUserId = items.CreatorUserId,
                            TenantId = items.TenantId,
                            CreditMemoHeaderId = items.CreditMemoHeaderId,
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
                        await _creditMemoDetailsAppService.UpdateAsync(toUpdate);
                    }
                }

            }
            else if(dto.CreditMemoMode == "Bad")
            {
                foreach (var dtoItem in dto.CreditMemoDetails)
                {
                    var check = await _badStockService.CheckIfExist(dtoItem.ProductId);
                    var old = await _creditMemoDetailsAppService.GetDetailsAsync(dtoItem.Id);
                    if (old != null)
                    {
                        if (dtoItem.TotalPieces > old.TotalPieces)
                        {
                            var change = dtoItem.TotalPieces - old.TotalPieces;
                            var tAmount = dtoItem.PricePerPiece * change;
                            check.TotalPieces += change;
                            check.Amount += tAmount;

                            await _badStockService.UpdateAsync(check);
                        }
                        else if (dtoItem.TotalPieces < old.TotalPieces)
                        {
                            var change = old.TotalPieces - dtoItem.TotalPieces;
                            var tAmount = dtoItem.PricePerPiece * change;
                            check.TotalPieces -= change;
                            check.Amount -= tAmount;

                            await _badStockService.UpdateAsync(check);
                        }
                    }
                    else
                    {
                        if(check != null)
                        {
                            check.TotalPieces += dtoItem.TotalPieces;
                            check.Amount += dtoItem.Amount;

                            await _badStockService.UpdateAsync(check);
                        }
                        else
                        {
                            var stocks = new BadStockDto
                            {
                                ProductId = dtoItem.ProductId,
                                TotalPieces = dtoItem.TotalPieces,
                                PricePerPiece = dtoItem.PricePerPiece,
                                Amount = dtoItem.Amount
                            };

                            await _badStockService.CreateAsync(stocks);
                        }
                    }
                }
                var updated = await _creditMemoAppService.UpdateAsync(dto);
                foreach (var items in dto.CreditMemoDetails)
                {
                    var getCheck = await _creditMemoDetailsAppService.GetAsync(new EntityDto<int>(items.Id));
                    if (getCheck == null)
                    {
                        var toCreate = new CreditMemoDetailDto
                        {
                            CreditMemoHeaderId = dto.CreditMemoId,
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
                        await _creditMemoDetailsAppService.CreateAsync(toCreate);

                    }
                    else if (getCheck != null)
                    {
                        var toUpdate = new CreditMemoDetailDto
                        {
                            Id = items.Id,
                            CreationTime = items.CreationTime,
                            CreatorUserId = items.CreatorUserId,
                            TenantId = items.TenantId,
                            CreditMemoHeaderId = items.CreditMemoHeaderId,
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
                        await _creditMemoDetailsAppService.UpdateAsync(toUpdate);
                    }
                }
            }
            
            return Ok(dto);
        }
        public async Task<ActionResult> GetLastCreditMemoCode()
        {
            var creditmemo = await _creditMemoAppService.GetLastCreditMemoCode();
            var model = ObjectMapper.Map<GetLastCreditMemoViewModel>(creditmemo);

            return Ok(model);
        }
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var header = await _creditMemoAppService.GetHeaderToExcel();
            var details = await _creditMemoDetailsAppService.GetDetailsToExcel();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Headers");
                var ws2 = excel.Workbook.Worksheets.Add("Details");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;

                ws.Cells["A5"].Value = "CM_No";
                ws.Cells["B5"].Value = "Cus_Name";
                ws.Cells["C5"].Value = "Salesman_Code";
                ws.Cells["D5"].Value = "T_Case";
                ws.Cells["E5"].Value = "T_Box";
                ws.Cells["F5"].Value = "T_Pieces";
                ws.Cells["G5"].Value = "T_Amount";
                ws.Cells["H5"].Value = "Terms";
                ws.Cells["I5"].Value = "Mode";
                ws.Cells["J5"].Value = "Date";
                int rowStart = 6;
                foreach (var item in header)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.CreditMemoCode;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.CustomerName;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.SalesmanCode;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.TotalCase;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.TotalBox;
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.TotalPiece;
                    ws.Cells[string.Format("G{0}", rowStart)].Value = item.TotalNet;
                    ws.Cells[string.Format("H{0}", rowStart)].Value = item.CustomerTerms;
                    ws.Cells[string.Format("I{0}", rowStart)].Value = item.CreditMemoMode;
                    ws.Cells[string.Format("J{0}", rowStart)].Value = item.CreditMemoDate;
                    ws.Cells[string.Format("J{0}", rowStart)].Style.Numberformat.Format = "mm/dd/yyyy";

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
                foreach (var item in details)
                {
                    ws2.Cells[string.Format("A{0}", rowStart1)].Value = item.CreditMemoHeaderCreditMemoCode;
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
                fileDownloadName: "CreditMemos.xlsx"
            );
        }
    }
}