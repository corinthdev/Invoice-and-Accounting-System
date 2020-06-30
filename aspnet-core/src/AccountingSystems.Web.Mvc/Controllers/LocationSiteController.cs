using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AccountingSystems.Controllers;
using AccountingSystems.LocationSites;
using AccountingSystems.Sessions;
using AccountingSystems.Web.Models.LocationSites;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Controllers
{
    [AbpMvcAuthorize]
    public class LocationSiteController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly ILocationSiteAppService _locationSiteAppService;
        public LocationSiteController(ISessionAppService sessionAppService,
                                      ILocationSiteAppService locationSiteAppService
                                     )
        {
            _sessionAppService = sessionAppService;
            _locationSiteAppService = locationSiteAppService;
        }
        public async Task<ActionResult> Index()
        {
            var model = new LocationSiteListViewModel
            {
                LocationSites = (await _locationSiteAppService.GetLocationSite()).Items
            };
            return View(model);
        }
        public async Task<ActionResult> Print()
        {
            var model = new PrintLocationSiteViewModel
            {
                LocationSites = (await _locationSiteAppService.GetLocationSite()).Items,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };
            return View(model);
        }
        public async Task<ActionResult> EditLocationSiteModal(int siteId)
        {
            var output = await _locationSiteAppService.GetForEdit(new EntityDto(siteId));
            var model = ObjectMapper.Map<EditLocationSiteModalViewModel>(output);

            return View("_EditLocationSiteModal", model);
        }
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var supplier = await _locationSiteAppService.GetSupplierToExcel();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Location Sites");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;
                ws.Cells["A2"].Value = "List of Sites for Credit Memo";

                ws.Cells["A5"].Value = "Site_Code";
                ws.Cells["B5"].Value = "Site_Description";

                int rowStart = 6;
                foreach (var item in supplier)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.SiteCode;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.Description;

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
                fileDownloadName: "LocationSites.xlsx"
            );
        }
    }
}