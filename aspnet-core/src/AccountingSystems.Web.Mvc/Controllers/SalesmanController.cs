using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AccountingSystems.Controllers;
using AccountingSystems.Salesmans;
using AccountingSystems.Salesmans.Dto;
using AccountingSystems.Sessions;
using AccountingSystems.Web.Models.Salesman;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Mvc.Controllers
{
    public class SalesmanController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly ISalesmanAppService _salesmanService;
        public SalesmanController(ISessionAppService sessionAppService,
                                  ISalesmanAppService salesmanService
                                 )
        {
            _sessionAppService = sessionAppService;
            _salesmanService = salesmanService;
        }
        public async Task<ActionResult> Index()
        {
            var salesman = (await _salesmanService.GetSalesman()).Items;
            var model = new SalesmanListViewModel
            {
                Salesmen = salesman
            };
            return View(model);
        }
        public async Task<ActionResult> Print()
        {
            var model = new PrintSalesmanViewModel
            {
                Salesmen = (await _salesmanService.GetSalesman()).Items,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };
            return View(model);
        }
        public async Task<ActionResult> EditSalesmanModal(int salesmanId)
        {
            var output = await _salesmanService.GetSalesmanForEdit(new EntityDto(salesmanId));
            var model = ObjectMapper.Map<EditSalesmanModalViewModel>(output);

            return View("_EditSalesmanModal", model);
        }

        public async Task<ActionResult> GetSalesmanName(string salesmanCode)
        {
            var output = await _salesmanService.GetSalesmanName(salesmanCode);
            var model = ObjectMapper.Map<GetSalesmanNameViewModel>(output);

            return Ok(model);
        }

        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var salesman = await _salesmanService.GetSalesmanToExcel();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using(var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Salesmen");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;
                ws.Cells["A2"].Value = "List of Salesman";

                ws.Cells["A5"].Value = "Salesman_Code";
                ws.Cells["B5"].Value = "Salesman_Name";
                ws.Cells["C5"].Value = "Salesman_Address";
                ws.Cells["D5"].Value = "Salesman_Town";
                ws.Cells["E5"].Value = "Salesman_Telephone";
                ws.Cells["F5"].Value = "Salesman_District";

                int rowStart = 6;
                foreach (var item in salesman)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.Code;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.Name;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.Address;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.Town;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.Telephone;
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.District;

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
                fileDownloadName: "ListOfSalesmen.xlsx"
            );
        }
    }
}