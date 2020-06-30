using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using AccountingSystems.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystems.Web.Controllers
{
    [AbpMvcAuthorize]
    public class GatepassController : AccountingSystemsControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}