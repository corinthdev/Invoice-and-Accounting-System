using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using AccountingSystems.BadStocks;
using AccountingSystems.Controllers;
using AccountingSystems.Products;
using AccountingSystems.Sessions;
using AccountingSystems.Web.Models.BadStock;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Controllers
{
    [AbpMvcAuthorize]
    public class BadStockController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IBadStockAppService _badStockService;
        private readonly IProductAppService _productService;
        public BadStockController(ISessionAppService sessionAppService,
                                  IBadStockAppService badStockService,
                                  IProductAppService productService
                                  )
        {
            _sessionAppService = sessionAppService;
            _badStockService = badStockService;
            _productService = productService;
        }
        public async Task<ActionResult> Index()
        {
            var stocks = (await _badStockService.GetStocks()).Items;
            var total = await _badStockService.GetTotal();
            var model = new BadStockListViewModel
            {
                StockListDtos = stocks,
                Total = total
            };
            return View(model);
        }
        public async Task<ActionResult> Print()
        {
            List<string> dups = new List<string>();
            var brands = (await _productService.GetProduct()).Items;
            foreach (var dups1 in brands)
            {
                dups.Add(dups1.Brand);
            }
            var dups2 = dups.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(x => x.Key)
                .ToList();
            var model = new BadStockListViewModel
            {
                StockListDtos = (await _badStockService.GetStocks()).Items,
                Total = await _badStockService.GetTotal(),
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
                ProductBrands = dups2
            };
            return View(model);
        }
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var header = await _badStockService.ExportToExcel();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Bad Stocks");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;

                ws.Cells["A5"].Value = "Prod_Code";
                ws.Cells["B5"].Value = "Prod_Description";
                ws.Cells["C5"].Value = "Prod_Brand";
                ws.Cells["D5"].Value = "TotalPieces";
                ws.Cells["E5"].Value = "PricePerPiece";
                ws.Cells["F5"].Value = "Amount";
                int rowStart = 6;
                foreach (var item in header)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.ProductCode;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.ProductItemName;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.ProductBrand;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.TotalPieces;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.ProductPricePerPiece;
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.Amount;

                    rowStart++;
                }

                ws.Cells["A:AZ"].AutoFitColumns();

                fileContents = excel.GetAsByteArray();
            }
            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }
            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Bad Stocks.xlsx"
            );
        }
    }
}