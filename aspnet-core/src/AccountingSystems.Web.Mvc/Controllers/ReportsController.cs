using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using AccountingSystems.Controllers;
using AccountingSystems.Invoices;
using AccountingSystems.Salesmans;
using AccountingSystems.Sessions;
using AccountingSystems.Web.Models.Reports;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystems.Web.Mvc.Controllers
{
    [AbpMvcAuthorize]
    public class ReportsController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IInvoiceAppService _invoiceAppService;
        private readonly ISalesmanAppService _salesmanAppService;

        public ReportsController(ISessionAppService sessionAppService, 
                                 IInvoiceAppService invoiceAppService, 
                                 ISalesmanAppService salesmanAppService
                                )
        {
            _sessionAppService = sessionAppService;
            _invoiceAppService = invoiceAppService;
            _salesmanAppService = salesmanAppService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreditMemoPrinting()
        {
            return View("CreditMemoPrinting");
        }
        public IActionResult SalesReport()
        {
            return View("SalesReport");
        }
        public async Task<ActionResult> InvoiceRegisterperSalesman()
        {
            var model = new AllInOneReportsViewModel
            {
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
                Invoices = await _invoiceAppService.GetAllInvoices(),
                Salesmans = (await _salesmanAppService.GetSalesman()).Items
            };

            return View("InvoiceRegisterperSalesman", model);
        }
    }
}