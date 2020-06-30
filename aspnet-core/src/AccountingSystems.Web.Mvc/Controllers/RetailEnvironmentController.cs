using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AccountingSystems.Controllers;
using AccountingSystems.RetailsEnvironments;
using AccountingSystems.Sessions;
using AccountingSystems.Web.Models.RetailEnvironments;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Controllers
{
    public class RetailEnvironmentController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IRetailEnvironmentAppService _retailenvService;
        public RetailEnvironmentController(ISessionAppService sessionAppService,
                                           IRetailEnvironmentAppService retailenvService
                                          )
        {
            _sessionAppService = sessionAppService;
            _retailenvService = retailenvService;
        }

        public async Task<ActionResult> Index()
        {
            var retailenv = (await _retailenvService.GetRetailEnvironment()).Items;
            var model = new RetailEnvironmentListViewModel
            {
                RetailEnvironment = retailenv
            };

            return View(model);
        }
        public async Task<ActionResult> Print()
        {
            var model = new PrintRetailEnvirontmentViewModel
            {
                RetailEnvirontments = (await _retailenvService.GetRetailEnvironment()).Items,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };
            return View(model);
        }
        public async Task<ActionResult> EditRetailEnvironmentModal(int retailenvId)
        {
            var output = await _retailenvService.GetRetailEnvironmentForEdit(new EntityDto(retailenvId));
            var model = ObjectMapper.Map<EditRetailEnvironmentModalViewModel>(output);


            return View("_EditRetailEnvironmentModal", model);
        }
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var retailenv = await _retailenvService.GetRetailEnvironmentToExcel();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Salesmen");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;
                ws.Cells["A2"].Value = "List of Salesman";

                ws.Cells["A5"].Value = "retail_Code";
                ws.Cells["B5"].Value = "retail_RE_Code";
                ws.Cells["C5"].Value = "retail_Sub_RE_Code";
                ws.Cells["D5"].Value = "retail_Description";
                ws.Cells["E5"].Value = "retail_CustomerType";

                int rowStart = 6;
                foreach (var item in retailenv)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.Code;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.RetailEnvironmentCode;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.SubRECode;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.Description;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.CustomerType;

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
                fileDownloadName: "RetailEnvironments.xlsx"
            );
        }
    }
}