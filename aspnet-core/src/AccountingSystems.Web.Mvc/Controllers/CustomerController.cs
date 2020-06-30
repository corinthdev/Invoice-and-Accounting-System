using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AccountingSystems.Controllers;
using AccountingSystems.Customers;
using AccountingSystems.RetailsEnvironments;
using AccountingSystems.Salesmans;
using AccountingSystems.Sessions;
using AccountingSystems.Vans;
using AccountingSystems.Web.Models.Customers;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Mvc.Controllers
{
    public class CustomerController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly ICustomerAppService _customerService;
        private readonly ISalesmanAppService _salesmanService;
        private readonly IRetailEnvironmentAppService _retailEnvService;
        public CustomerController(ISessionAppService sessionAppService,
                                  ICustomerAppService customerService, 
                                  ISalesmanAppService salesmanService, 
                                  IRetailEnvironmentAppService retailEnvService)
        {
            _sessionAppService = sessionAppService;
            _customerService = customerService;
            _salesmanService = salesmanService;
            _retailEnvService = retailEnvService;
        }
        public async Task<ActionResult> Index()
        {
            var customers = (await _customerService.GetCustomer()).Items;
            var salesmans = (await _salesmanService.GetSalesman()).Items;
            var retailenvs = (await _retailEnvService.GetRetailEnvironment()).Items;
            var model = new CustomerListViewModel
            {
                Customers = customers,
                Salesmen = salesmans,
                RetailEnvironmentLists = retailenvs
            };
            return View(model);
        }

        public async Task<ActionResult> EditCustomerModal(int customerId)
        {
            var output = await _customerService.GetCustomerForEdit(new EntityDto(customerId));
            var salesmans = (await _salesmanService.GetSalesman()).Items;
            var retailenvs = (await _retailEnvService.GetRetailEnvironment()).Items;
            var model = new EditCustomerModalViewModel
            {
                CustomerEdit = output,
                Salesmen = salesmans,
                RetailEnvironmentLists = retailenvs
            };

            return View("_EditCustomerModal", model);
        }

        public async Task<ActionResult> Print()
        {
            var model = new PrintCustomerViewModel
            {
                Customers = await _customerService.GetAllCustomer(),
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };

            return View(model);
        }
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var customers = await _customerService.GetAllCustomer();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Customers");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;
                ws.Cells["A2"].Value = "List of Customers";

                ws.Cells["A5"].Value = "Cus_Code";
                ws.Cells["B5"].Value = "Cus_Code1";
                ws.Cells["C5"].Value = "Cus_Code2";
                ws.Cells["D5"].Value = "Cus_RegName";
                ws.Cells["E5"].Value = "Cus_HouseNo";
                ws.Cells["F5"].Value = "Cus_street";
                ws.Cells["G5"].Value = "Cus_Brgy";
                ws.Cells["H5"].Value = "Cus_Municipality";
                ws.Cells["I5"].Value = "Cus_Province";
                ws.Cells["J5"].Value = "Cus_ContactPerson";
                ws.Cells["K5"].Value = "Cus_Telephone";
                ws.Cells["L5"].Value = "Cus_Salesman";
                ws.Cells["M5"].Value = "Cus_Terms";
                ws.Cells["N5"].Value = "Cus_RE";
                ws.Cells["O5"].Value = "Cus_Disc1";
                ws.Cells["P5"].Value = "Cus_Disc2";
                ws.Cells["Q5"].Value = "Cus_Disc3";
                ws.Cells["R5"].Value = "Cus_Disc4";
                ws.Cells["S5"].Value = "Cus_CredLimit";

                int rowStart = 6;
                foreach (var item in customers)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.Code;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.PrincipalCode1;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.PrincipalCode2;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.Name;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.HouseNumber;
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.Street;
                    ws.Cells[string.Format("G{0}", rowStart)].Value = item.Barangay;
                    ws.Cells[string.Format("H{0}", rowStart)].Value = item.Municipality;
                    ws.Cells[string.Format("I{0}", rowStart)].Value = item.Province;
                    ws.Cells[string.Format("J{0}", rowStart)].Value = item.ContactPerson;
                    ws.Cells[string.Format("K{0}", rowStart)].Value = item.Telephone;
                    ws.Cells[string.Format("L{0}", rowStart)].Value = item.SalesmanName;
                    ws.Cells[string.Format("M{0}", rowStart)].Value = item.Terms;
                    ws.Cells[string.Format("N{0}", rowStart)].Value = item.KindofBranch;
                    ws.Cells[string.Format("O{0}", rowStart)].Value = item.Disc1;
                    ws.Cells[string.Format("P{0}", rowStart)].Value = item.Disc2;
                    ws.Cells[string.Format("Q{0}", rowStart)].Value = item.Disc3;
                    ws.Cells[string.Format("R{0}", rowStart)].Value = item.Disc4;
                    ws.Cells[string.Format("S{0}", rowStart)].Value = item.CreditLimit;

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
                fileDownloadName: "Customers.xlsx"
            );
        }
    }
}