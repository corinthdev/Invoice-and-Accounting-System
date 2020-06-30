using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AccountingSystems.Controllers;
using AccountingSystems.Sessions;
using AccountingSystems.Suppliers;
using AccountingSystems.Web.Models.Suppliers;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Mvc.Controllers
{
    public class SupplierController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly ISupplierAppService _supplierService;
        public SupplierController(ISessionAppService sessionAppService,
                                  ISupplierAppService supplierService
                                 )
        {
            _sessionAppService = sessionAppService;
            _supplierService = supplierService;
        }
        public async Task<ActionResult> Index()
        {
            var suppliers = (await _supplierService.GetSupplier()).Items;
            var model = new SupplierListViewModel
            {
                Supplier = suppliers
            };
            return View(model);
        }
        public async Task<ActionResult> Print()
        {
            var model = new PrintSupplierViewModel
            {
                Suppliers = (await _supplierService.GetSupplier()).Items,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };

            return View(model);
        }
        public async Task<ActionResult> EditSupplierModal(int supplierId)
        {
            var output = await _supplierService.GetSupplierForEdit(new EntityDto(supplierId));
            var model = ObjectMapper.Map<EditSupplierModalViewModel>(output);

            return View("_EditSupplierModal", model);
        }

        public async Task<ActionResult> GetSupplierName(string supplierCode)
        {
            var output = await _supplierService.GetSupplierName(supplierCode);
            var model = ObjectMapper.Map<GetSupplierNameViewModel>(output);

            return Ok(model);
        }
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var supplier = await _supplierService.GetSupplierToExcel();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Suppliers");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;
                ws.Cells["A2"].Value = "List of Suppliers";

                ws.Cells["A5"].Value = "Sup_Code";
                ws.Cells["B5"].Value = "Sup_Name";
                ws.Cells["C5"].Value = "Sup_Address";
                ws.Cells["D5"].Value = "Sup_Telephone";

                int rowStart = 6;
                foreach (var item in supplier)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.Code;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.Name;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.Address;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.Telephone;

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
                fileDownloadName: "Suppliers.xlsx"
            );
        }
    }
}