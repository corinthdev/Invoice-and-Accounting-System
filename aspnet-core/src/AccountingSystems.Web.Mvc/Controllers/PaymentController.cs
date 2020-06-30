using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystems.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystems.Web.Controllers
{
    public class PaymentController : AccountingSystemsControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}