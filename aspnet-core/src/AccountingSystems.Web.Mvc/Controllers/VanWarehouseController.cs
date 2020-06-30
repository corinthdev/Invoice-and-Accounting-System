using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AccountingSystems.Controllers;
using AccountingSystems.Salesmans;
using AccountingSystems.Sessions;
using AccountingSystems.Vans;
using AccountingSystems.Vans.Dto;
using AccountingSystems.VanStocks;
using AccountingSystems.Web.Models.Vans;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Controllers
{
    public class VanWarehouseController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IVanAppService _vanService;
        private readonly ISalesmanAppService _salesmanService;
        private readonly IVanStockAppService _vanStockService;
        public VanWarehouseController(ISessionAppService sessionAppService,
                                      IVanAppService vanService, 
                                      ISalesmanAppService salesmanService,
                                      IVanStockAppService vanStockService)
        {
            _sessionAppService = sessionAppService;
            _vanService = vanService;
            _salesmanService = salesmanService;
            _vanStockService = vanStockService;
        }
        public async Task<ActionResult> Index()
        {
            var vans = (await _vanService.GetVan()).Items;
            var salesman = (await _salesmanService.GetSalesman()).Items;
            var model = new VanListViewModel
            {
                Vans = vans,
                Salesmen = salesman
            };
            return View(model);
        }
        public async Task<ActionResult> View(int vanId)
        {
            var vanStocks = (await _vanStockService.GetVanStocks(vanId)).Items;
            var total = await _vanStockService.GetTotal(vanId);
            var model = new VanStockListViewModel
            {
                VanStockLists = vanStocks,
                Total = total
            };
            return View("View", model);
        }
        public async Task<ActionResult> Print(int vanId)
        {
            var model = new PrintVanStocksViewModel
            {
                VanStockLists = await _vanStockService.GetVanStocksToExcel(),
                Vans = (await _vanService.GetVan()).Items,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };
            return View("Print", model);
        }
        public async Task<ActionResult> EditVanModal(int vanId)
        {
            var output = await _vanService.GetVanForEdit(new EntityDto(vanId));
            var salesman = (await _salesmanService.GetSalesman()).Items;
            var model = new EditVanModalViewModel
            {
                VanEdit = output,
                Salesmen = salesman
            };

            return View("_EditVanModal", model);
        }

        public async Task<ActionResult> GetVanName(string vanCode)
        {
            var output = await _vanService.GetVAnName(vanCode);
            var model = ObjectMapper.Map<GetVanNameForOutput>(output);

            return Ok(model);
        }
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;

            var vans = await _vanService.GetVanToExcel();
            var vanStocks = await _vanStockService.GetVanStocksToExcel();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Van Warehouse");

                ws.Cells["A1"].Value = currentTenant.Tenant.Name;

                ws.Cells["A5"].Value = "Van_code";
                ws.Cells["B5"].Value = "Prod_Code";
                ws.Cells["C5"].Value = "Prod_Description";
                ws.Cells["D5"].Value = "Prod_Brand";
                ws.Cells["E5"].Value = "TotalPieces";
                ws.Cells["F5"].Value = "PricePerPiece";
                ws.Cells["G5"].Value = "Amount";
                int rowStart = 6;
                foreach(var vanname in vans)
                {
                    foreach (var item in vanStocks)
                    {
                        if(vanname.Name == item.VanName)
                        {
                            ws.Cells[string.Format("A{0}", rowStart)].Value = item.VanName;
                            ws.Cells[string.Format("B{0}", rowStart)].Value = item.ProductCode;
                            ws.Cells[string.Format("C{0}", rowStart)].Value = item.ProductItemName;
                            ws.Cells[string.Format("D{0}", rowStart)].Value = item.ProductBrand;
                            ws.Cells[string.Format("E{0}", rowStart)].Value = item.TotalPieces;
                            ws.Cells[string.Format("F{0}", rowStart)].Value = item.ProductPricePerPiece;
                            ws.Cells[string.Format("G{0}", rowStart)].Value = item.Amount;

                            rowStart++;
                        }
                        
                    }
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
                fileDownloadName: "VanWarehouse.xlsx"
            );
        }
    }
}