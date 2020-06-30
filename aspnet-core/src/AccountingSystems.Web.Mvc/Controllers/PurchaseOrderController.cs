using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AccountingSystems.Controllers;
using AccountingSystems.Products;
using AccountingSystems.PurchaseOrders;
using AccountingSystems.PurchaseOrders.Dto;
using AccountingSystems.Sessions;
using AccountingSystems.Stocks;
using AccountingSystems.Stocks.Dto;
using AccountingSystems.Suppliers;
using AccountingSystems.Web.Models.PurchaseOrder;
using AccountingSystems.Web.Models.Transaction;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Mvc.Controllers
{
    public class PurchaseOrderController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly ISupplierAppService _supplierService;
        private readonly IProductAppService _productService;
        private readonly IPurchaseOrderAppService _purchaseOderService;
        private readonly IPurchaseOrderDetailsAppService _purchaseOrderDetailsService;
        private readonly IStockAppService _stockService;

        public PurchaseOrderController(ISessionAppService sessionAppService,
                                       ISupplierAppService supplierService, 
                                       IProductAppService productService,
                                       IPurchaseOrderAppService purchaseOderService,
                                       IPurchaseOrderDetailsAppService purchaseOrderDetailsService,
                                       IStockAppService stockService
                                       )
        {
            _sessionAppService = sessionAppService;
            _supplierService = supplierService;
            _productService = productService;
            _purchaseOderService = purchaseOderService;
            _purchaseOrderDetailsService = purchaseOrderDetailsService;
            _stockService = stockService;
        }
        public async Task<ActionResult> Index()
        {
            var purchaseOrders = (await _purchaseOderService.GetPurchaseOrder()).Items;
            var model = new PurchaseOrderListViewModel
            {
                PurchaseOrders = purchaseOrders
            };
            return View(model);
        }
        public async Task<ActionResult> Create()
        {
            var suppliers = (await _supplierService.GetSupplier()).Items;
            var products = (await _productService.GetProduct()).Items;

            var model = new CreatePurchaseOrderViewModel
            {
                Suppliers = suppliers,
                Products = products,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
            };
            return View("Create", model);
        }
        [HttpPost]
        public async Task<ActionResult> CreatePurchaseOrder(CreatePurchaseOrderDto dto)
        {
            await _purchaseOderService.CreateAsync(dto);

            foreach (var items in dto.PurchaseOrderDetails)
            {
                var check = await _stockService.CheckIfExist(items.ProductId);
                if (check != null)
                {
                    check.TotalPieces += items.TotalPieces;
                    check.Amount += items.Amount;
                    await _stockService.UpdateAsync(check);
                }
                else
                {
                    var stocks = new StockDto
                    {
                        ProductId = items.ProductId,
                        TotalPieces = items.TotalPieces,
                        PricePerPiece = items.PricePerPiece,
                        Amount = items.Amount
                    };

                    await _stockService.CreateAsync(stocks);

                }

            }

            return Ok(dto);
        }
        public async Task<ActionResult> View(int purchaseOrderId)
        {
            var invoice = await _purchaseOderService.GetPurchaseOrderForEdit(new EntityDto(purchaseOrderId));
            var model = ObjectMapper.Map<ViewPurchaseOrderViewModel>(invoice);
            return View("View", model);
        }
        public async Task<ActionResult> Print(int purchaseOrderId)
        {
            var invoice = await _purchaseOderService.GetPurchaseOrderForEdit(new EntityDto(purchaseOrderId));
            var model = ObjectMapper.Map<ViewPurchaseOrderViewModel>(invoice);
            return View("Print", model);
        }
        public async Task<ActionResult> Edit(int purchaseOrderId)
        {
            var invoice = await _purchaseOderService.GetPurchaseOrderForEdit(new EntityDto(purchaseOrderId));
            var model = ObjectMapper.Map<EditPurchaseOrderViewModel>(invoice);
            return View("Edit", model);
        }
        [HttpPost]
        public async Task<ActionResult> EditPurchaseOrder(PurchaseOrderHeaderDto dto)
        {
            foreach (var dtoItem in dto.PurchaseOrderDetails)
            {
                var check = await _stockService.CheckIfExist(dtoItem.ProductId);
                var old = await _purchaseOrderDetailsService.GetDetailsAsync(dtoItem.Id);
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
            var updated = await _purchaseOderService.UpdateAsync(dto);
            foreach (var items in dto.PurchaseOrderDetails)
            {
                var getCheck = await _purchaseOrderDetailsService.GetAsync(new EntityDto<int>(items.Id));
                if (getCheck == null)
                {
                    var toCreate = new PurchaseOrderDetailDto
                    {
                        PurchaseOrderHeaderId = dto.PurchaseOrderId,
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
                    await _purchaseOrderDetailsService.CreateAsync(toCreate);

                }
                else if (getCheck != null)
                {
                    var toUpdate = new PurchaseOrderDetailDto
                    {
                        Id = items.Id,
                        CreationTime = items.CreationTime,
                        CreatorUserId = items.CreatorUserId,
                        TenantId = items.TenantId,
                        PurchaseOrderHeaderId = items.PurchaseOrderHeaderId,
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
                    await _purchaseOrderDetailsService.UpdateAsync(toUpdate);
                }
            }

            return Ok(updated);
        }
        public async Task<ActionResult> GetLastInvoiceCode()
        {
            var invoice = await _purchaseOderService.GetLastPurchaseOrderCode();
            var model = ObjectMapper.Map<GetLastPurchaseOrderViewModel>(invoice);

            return Ok(model);
        }
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var header = await _purchaseOderService.GetHeaderToExcel();
            var details = await _purchaseOrderDetailsService.GetDetailsToExcel();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Headers");
                var ws2 = excel.Workbook.Worksheets.Add("Details");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;

                ws.Cells["A5"].Value = "Purchase_No";
                ws.Cells["B5"].Value = "Supplier_Code";
                ws.Cells["C5"].Value = "T_Case";
                ws.Cells["D5"].Value = "T_Box";
                ws.Cells["E5"].Value = "T_Pieces";
                ws.Cells["F5"].Value = "T_Amount";
                ws.Cells["G5"].Value = "Date";
                int rowStart = 6;
                foreach (var item in header)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.PurchaseOrderCode;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.SupplierCode;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.TotalCase;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.TotalBox;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.TotalPiece;
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.TotalNet;
                    ws.Cells[string.Format("G{0}", rowStart)].Value = item.PurchaseOrderDate;
                    ws.Cells[string.Format("G{0}", rowStart)].Style.Numberformat.Format = "mm/dd/yyyy";

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
                    ws2.Cells[string.Format("A{0}", rowStart1)].Value = item.PurchaseOrderHeaderPurchaseOrderCode;
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
                fileDownloadName: "PurchaseOrders.xlsx"
            );
        }
    }
}