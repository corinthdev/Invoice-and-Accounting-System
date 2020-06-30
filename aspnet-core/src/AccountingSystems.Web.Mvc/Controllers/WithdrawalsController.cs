using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AccountingSystems.Controllers;
using AccountingSystems.Products;
using AccountingSystems.Sessions;
using AccountingSystems.Stocks;
using AccountingSystems.Vans;
using AccountingSystems.VanStocks;
using AccountingSystems.VanStocks.dto;
using AccountingSystems.Web.Models.Transaction;
using AccountingSystems.Web.Models.Withdrawals;
using AccountingSystems.Withdrawals;
using AccountingSystems.Withdrawals.Dto;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Controllers
{
    [AbpMvcAuthorize]
    public class WithdrawalsController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IVanAppService _vanService;
        private readonly IProductAppService _productService;
        private readonly IWithdrawalAppService _withdrawalService;
        private readonly IWithdrawalDetailsAppService _withdrawalDetailsService;
        private readonly IStockAppService _stockService;
        private readonly IVanStockAppService _vanStockService;
        public WithdrawalsController(ISessionAppService sessionAppService,
                                     IVanAppService vanService,
                                     IProductAppService productService,
                                     IWithdrawalAppService withdrawalService,
                                     IWithdrawalDetailsAppService withdrawalDetailsService,
                                     IStockAppService stockService,
                                     IVanStockAppService vanStockService
                                    )
        {
            _sessionAppService = sessionAppService;
            _vanService = vanService;
            _vanStockService = vanStockService;
            _stockService = stockService;
            _productService = productService;
            _withdrawalService = withdrawalService;
            _withdrawalDetailsService = withdrawalDetailsService;
        }
        public async Task<ActionResult> Index()
        {
            var withdrawals = (await _withdrawalService.GetWithdrawal()).Items;
            var model = new WithdrawalListViewModel
            {
                Withdrawals = withdrawals
            };
            return View(model);
        }
        public async Task<ActionResult> Create()
        {
            var vans = (await _vanService.GetVan()).Items;
            var products = (await _productService.GetProduct()).Items;

            var model = new CreateWithdrawalViewModel
            {
                Vans = vans,
                Products = products,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
            };
            return View("Create", model);
        }
        [HttpPost]
        public async Task<ActionResult> CreateWithdrawal(CreateWithdrawalDto dto)
        {
            var created = await _withdrawalService.CreateAsync(dto);

            foreach (var items in dto.WithdrawalDetails)
            {
                var check = await _vanStockService.CheckIfExist(items.ProductId, dto.VanId);
                var check2 = await _stockService.CheckIfExist(items.ProductId);
                if (check2 != null)
                {
                    check2.TotalPieces -= items.TotalPieces;
                    check2.Amount -= items.Amount;
                    await _stockService.UpdateAsync(check2);
                }
                
                if (check != null)
                {
                    check.TotalPieces += items.TotalPieces;
                    check.Amount += items.Amount;
                    await _vanStockService.UpdateAsync(check);
                }
                else
                {
                    var stocks = new VanStockDto
                    {
                        ProductId = items.ProductId,
                        TotalPieces = items.TotalPieces,
                        PricePerPiece = items.PricePerPiece,
                        Amount = items.Amount,
                        VanId = dto.VanId
                    };
                    await _vanStockService.CreateAsync(stocks);
                    
                }
                
            }

            return Ok(created);
        }
        public async Task<ActionResult> View(int withdrawalId)
        {
            var withdrawals = await _withdrawalService.GetWithdrawalForEdit(new EntityDto(withdrawalId));
            var model = ObjectMapper.Map<ViewWithdrawalViewModel>(withdrawals);
            return View("View", model);
        }
        public async Task<ActionResult> Print(int withdrawalId)
        {
            var withdrawals = await _withdrawalService.GetWithdrawalForEdit(new EntityDto(withdrawalId));
            var model = ObjectMapper.Map<ViewWithdrawalViewModel>(withdrawals);
            return View("Print", model);
        }
        public async Task<ActionResult> Edit(int withdrawalId)
        {
            var withdrawals = await _withdrawalService.GetWithdrawalForEdit(new EntityDto(withdrawalId));
            var model = ObjectMapper.Map<EditWithdrawalViewModel>(withdrawals);
            return View("Edit", model);
        }
        [HttpPost]
        public async Task<ActionResult> EditWithdrawal(WithdrawalHeaderDto dto)
        {
            foreach (var dtoItem in dto.WithdrawalDetails)
            {
                var check = await _vanStockService.CheckIfExist(dtoItem.ProductId, dto.VanId);
                var check2 = await _stockService.CheckIfExist(dtoItem.ProductId);
                var old = await _withdrawalDetailsService.GetDetailsAsync(dtoItem.Id);
                if (old != null)
                {
                    if (dtoItem.TotalPieces > old.TotalPieces)
                    {
                        var change = dtoItem.TotalPieces - old.TotalPieces;
                        var tAmount = dtoItem.PricePerPiece * change;
                        check.TotalPieces += change;
                        check.Amount += tAmount;

                        check2.TotalPieces -= change;
                        check2.Amount -= tAmount;

                        await _vanStockService.UpdateAsync(check);
                        await _stockService.UpdateAsync(check2);
                    }
                    else if (dtoItem.TotalPieces < old.TotalPieces)
                    {
                        var change = old.TotalPieces - dtoItem.TotalPieces;
                        var tAmount = dtoItem.PricePerPiece * change;
                        check.TotalPieces -= change;
                        check.Amount -= tAmount;

                        check2.TotalPieces += change;
                        check2.Amount += tAmount;

                        await _vanStockService.UpdateAsync(check);
                        await _stockService.UpdateAsync(check2);
                    }
                }
                else
                {
                    if (check != null)
                    {
                        check.TotalPieces += dtoItem.TotalPieces;
                        check.Amount += dtoItem.Amount;

                        check2.TotalPieces -= dtoItem.TotalPieces;
                        check2.Amount -= dtoItem.Amount;

                        await _stockService.UpdateAsync(check2);
                        await _vanStockService.UpdateAsync(check);
                    }
                    else
                    {
                        check2.TotalPieces -= dtoItem.TotalPieces;
                        check2.Amount -= dtoItem.Amount;
                        await _stockService.UpdateAsync(check2);

                        var stocks = new VanStockDto
                        {
                            ProductId = dtoItem.ProductId,
                            TotalPieces = dtoItem.TotalPieces,
                            PricePerPiece = dtoItem.PricePerPiece,
                            Amount = dtoItem.Amount,
                            VanId = dto.VanId
                        };

                        await _vanStockService.CreateAsync(stocks);
                    }
                }
            }
            var updated = await _withdrawalService.UpdateAsync(dto);
            foreach (var items in dto.WithdrawalDetails)
            {
                var getCheck = await _withdrawalDetailsService.GetAsync(new EntityDto<int>(items.Id));
                if (getCheck == null)
                {
                    var toCreate = new WithdrawalDetailDto
                    {
                        WithdrawalHeaderId = dto.WithdrawalId,
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
                    await _withdrawalDetailsService.CreateAsync(toCreate);

                }
                else if (getCheck != null)
                {
                    var toUpdate = new WithdrawalDetailDto
                    {
                        Id = items.Id,
                        CreationTime = items.CreationTime,
                        CreatorUserId = items.CreatorUserId,
                        TenantId = items.TenantId,
                        WithdrawalHeaderId = items.WithdrawalHeaderId,
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
                    await _withdrawalDetailsService.UpdateAsync(toUpdate);
                }
            }

            return Ok(updated);
        }

        public async Task<ActionResult> GetLastWithdrawalCode()
        {
            var invoice = await _withdrawalService.GetLastWithdrawalCode();
            var model = ObjectMapper.Map<GetLastWithdrawalViewModel>(invoice);

            return Ok(model);
        }
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var header = await _withdrawalService.GetHeaderToExcel();
            var details = await _withdrawalDetailsService.GetDetailsToExcel();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Headers");
                var ws2 = excel.Workbook.Worksheets.Add("Details");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;

                ws.Cells["A5"].Value = "Withdrawal_No";
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
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.WithdrawalCode;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.VanCode;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.VanPlateNumber;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.SalesmanCode;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.TotalCase;
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.TotalBox;
                    ws.Cells[string.Format("G{0}", rowStart)].Value = item.TotalPiece;
                    ws.Cells[string.Format("H{0}", rowStart)].Value = item.TotalNet;
                    ws.Cells[string.Format("I{0}", rowStart)].Value = item.WithdrawalDate;
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
                    ws2.Cells[string.Format("A{0}", rowStart1)].Value = item.WithdrawalHeaderWithdrawalCode;
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
                fileDownloadName: "Withdrawals.xlsx"
            );
        }
    }
}