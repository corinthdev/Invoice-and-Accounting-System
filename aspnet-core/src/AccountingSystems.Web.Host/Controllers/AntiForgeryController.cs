using Microsoft.AspNetCore.Antiforgery;
using AccountingSystems.Controllers;

namespace AccountingSystems.Web.Host.Controllers
{
    public class AntiForgeryController : AccountingSystemsControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
