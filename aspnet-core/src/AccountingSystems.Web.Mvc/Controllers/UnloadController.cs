using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.UI;
using AccountingSystems.Controllers;
using AccountingSystems.Products;
using AccountingSystems.Sessions;
using AccountingSystems.Stocks;
using AccountingSystems.Unloads;
using AccountingSystems.Unloads.Dto;
using AccountingSystems.Vans;
using AccountingSystems.VanStocks;
using AccountingSystems.Web.Models.Transaction;
using AccountingSystems.Web.Models.Unload;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Controllers
{
    [AbpMvcAuthorize]
    public class UnloadController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IVanAppService _vanService;
        private readonly IProductAppService _productService;
        private readonly IStockAppService _stockService;
        private readonly IVanStockAppService _vanStockService;
        private readonly IUnloadAppService _unloadService;
        private readonly IUnloadDetailsAppService _unloadDetailsService;
        public UnloadController(ISessionAppService sessionAppService,
                                IVanAppService vanService,
                                IProductAppService productService,
                                IStockAppService stockService,
                                IVanStockAppService vanStockService,
                                IUnloadAppService unloadService,
                                IUnloadDetailsAppService unloadDetailsService
                                )
        {
            _sessionAppService = sessionAppService;
            _vanService = vanService;
            _vanStockService = vanStockService;
            _stockService = stockService;
            _productService = productService;
            _unloadService = unloadService;
            _unloadDetailsService = unloadDetailsService;
        }
        public async Task<ActionResult> Index()
        {
            var unloads = (await _unloadService.GetUnload()).Items;
            var model = new UnloadListViewModel
            {
                Unloads = unloads
            };
            return View(model);
        }
        public async Task<ActionResult> Create()
        {
            var vans = (await _vanService.GetVan()).Items;
            var products = (await _productService.GetProduct()).Items;

            var model = new CreateUnloadViewModel
            {
                Vans = vans,
                Products = products,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
            };
            return View("Create", model);
        }
        [HttpPost]
        public async Task<ActionResult> CreateUnload(CreateUnloadDto dto)
        {
            var created = await _unloadService.CreateAsync(dto);

            foreach (var items in dto.UnloadDetails)
            {
                var check = await _vanStockService.CheckIfExist(items.ProductId, dto.VanId);
                var check2 = await _stockService.CheckIfExist(items.ProductId);
                if (check2 != null)
                {
                    check2.TotalPieces += items.TotalPieces;
                    check2.Amount += items.Amount;
                   await _stockService.UpdateAsync(check2);
                }

                if (check != null)
                {
                    check.TotalPieces -= items.TotalPieces;
                    check.Amount -= items.Amount;
                    await _vanStockService.UpdateAsync(check);
                }
            }

            return Ok(created);
        }
        public async Task<ActionResult> View(int unloadId)
        {
            var unloads = await _unloadService.GetUnloadForEdit(new EntityDto(unloadId));
            var model = ObjectMapper.Map<ViewUnloadViewModel>(unloads);
            return View("View", model);
        }
        public async Task<ActionResult> Print(int unloadId)
        {
            var unloads = await _unloadService.GetUnloadForEdit(new EntityDto(unloadId));
            var model = ObjectMapper.Map<ViewUnloadViewModel>(unloads);
            return View("Print", model);
        }
        public async Task<ActionResult> Edit(int unloadId)
        {
            var unloads = await _unloadService.GetUnloadForEdit(new EntityDto(unloadId));
            var model = ObjectMapper.Map<EditUnloadViewModel>(unloads);
            return View("Edit", model);
        }
        [HttpPost]
        public async Task<ActionResult> EditUnload(UnloadHeaderDto dto)
        {
            foreach (var dtoItem in dto.UnloadDetails)
            {
                var check = await _vanStockService.CheckIfExist(dtoItem.ProductId, dto.VanId);
                var check2 = await _stockService.CheckIfExist(dtoItem.ProductId);
                var old = await _unloadDetailsService.GetDetailsAsync(dtoItem.Id);
                if (old != null)
                {
                    if (dtoItem.TotalPieces > old.TotalPieces)
                    {
                        var change = dtoItem.TotalPieces - old.TotalPieces;
                        var tAmount = dtoItem.PricePerPiece * change;
                        check.TotalPieces -= change;
                        check.Amount -= tAmount;

                        check2.TotalPieces += change;
                        check2.Amount += tAmount;

                        await _vanStockService.UpdateAsync(check);
                        await _stockService.UpdateAsync(check2);
                    }
                    else if (dtoItem.TotalPieces < old.TotalPieces)
                    {
                        var change = old.TotalPieces - dtoItem.TotalPieces;
                        var tAmount = dtoItem.PricePerPiece * change;
                        check.TotalPieces += change;
                        check.Amount += tAmount;

                        check2.TotalPieces -= change;
                        check2.Amount -= tAmount;

                        await _vanStockService.UpdateAsync(check);
                        await _stockService.UpdateAsync(check2);
                    }
                }
                else
                {
                    if (check != null)
                    {
                        check.TotalPieces -= dtoItem.TotalPieces;
                        check.Amount -= dtoItem.Amount;

                        check2.TotalPieces += dtoItem.TotalPieces;
                        check2.Amount += dtoItem.Amount;

                        await _stockService.UpdateAsync(check2);
                        await _vanStockService.UpdateAsync(check);
                    }
                    else
                    {
                        check2.TotalPieces += dtoItem.TotalPieces;
                        check2.Amount += dtoItem.Amount;
                        await _stockService.UpdateAsync(check2);
                    }
                }
            }
            var updated = await _unloadService.UpdateAsync(dto);
            foreach (var items in dto.UnloadDetails)
            {
                var getCheck = await _unloadDetailsService.GetAsync(new EntityDto<int>(items.Id));
                if (getCheck == null)
                {
                    var toCreate = new UnloadDetailDto
                    {
                        UnloadHeaderId = dto.UnloadId,
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
                    await _unloadDetailsService.CreateAsync(toCreate);

                }
                else if (getCheck != null)
                {
                    var toUpdate = new UnloadDetailDto
                    {
                        Id = items.Id,
                        CreationTime = items.CreationTime,
                        CreatorUserId = items.CreatorUserId,
                        TenantId = items.TenantId,
                        UnloadHeaderId = items.UnloadHeaderId,
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
                    await _unloadDetailsService.UpdateAsync(toUpdate);
                }
            }

            return Ok(updated);
        }
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var header = await _unloadService.GetHeaderToExcel();
            var details = await _unloadDetailsService.GetDetailsToExcel();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Headers");
                var ws2 = excel.Workbook.Worksheets.Add("Details");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;

                ws.Cells["A5"].Value = "Unload_No";
                ws.Cells["B5"].Value = "Van_Code";
                ws.Cells["C5"].Value = "Plate_Number";
                ws.Cells["D5"].Value = "Salesman_Code";
                ws.Cells["E5"].Value = "T_Case";
                ws.Cells["F5"].Value = "T_Box";
                ws.Cells["G5"].Value = "T_Pieces";
                ws.Cells["H5"].Value = "T_Amount";
                ws.Cells["I5"].Value = "Date";
                int rowStart = 6;
                foreach (var item in header)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.UnloadCode;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.VanCode;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.VanPlateNumber;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.SalesmanCode;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.TotalCase;
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.TotalBox;
                    ws.Cells[string.Format("G{0}", rowStart)].Value = item.TotalPiece;
                    ws.Cells[string.Format("H{0}", rowStart)].Value = item.TotalNet;
                    ws.Cells[string.Format("I{0}", rowStart)].Value = item.UnloadDate;
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
                foreach (var item in details)
                {
                    ws2.Cells[string.Format("A{0}", rowStart1)].Value = item.UnloadHeaderUnloadCode;
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
                fileDownloadName: "Unloads.xlsx"
            );
        }
    }
}