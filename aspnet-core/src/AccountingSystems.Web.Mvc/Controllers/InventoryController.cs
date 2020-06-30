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
    public class InventoryController : AccountingSystemsControllerBase
    {
        public IActionResult Inventory()
        {
            return View("Inventory");
        }
        public IActionResult Expiry()
        {
            return View("Expiry");
        }
    }
}