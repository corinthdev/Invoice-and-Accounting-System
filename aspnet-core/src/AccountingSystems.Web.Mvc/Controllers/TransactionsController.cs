using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using AccountingSystems.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystems.Web.Mvc.Controllers
{
    [AbpMvcAuthorize]
    public class TransactionsController : AccountingSystemsControllerBase
    {
        public IActionResult Invoicing()
        {
            return View("Invoicing");
        }
        public IActionResult AddInvoice()
        {
            return View("AddInVoice");
        }
        public IActionResult ExTruck()
        {
            return View("ExTruck");
        }
        public IActionResult Purchasing()
        {
            return View("Purchasing");
        }
        public IActionResult CreditMemo()
        {
            return View("CreditMemo");
        }
        public IActionResult ReturnCM()
        {
            return View("ReturnCM");
        }
        public IActionResult Transfer()
        {
            return View("Transfer");
        }
    }
}