using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AccountingSystems.Controllers;

namespace AccountingSystems.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : AccountingSystemsControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
