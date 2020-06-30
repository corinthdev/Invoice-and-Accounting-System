using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystems.Controllers;
using AccountingSystems.Products;
using AccountingSystems.Web.Models.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystems.Web.Mvc.Controllers
{
    public class TransferStockController : AccountingSystemsControllerBase
    {
        private readonly IProductAppService _productService;

        public TransferStockController(IProductAppService productService)
        {
            _productService = productService;        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CreateTransferStock()
        {
            var products = (await _productService.GetProduct()).Items;

            var model = new CreateTransferStockViewModel
            {
                Products = products
            };
            return View("CreateTransferStock", model);
        }

    }
}