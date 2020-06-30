using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystems.Controllers;
using AccountingSystems.Customers;
using AccountingSystems.Products;
using AccountingSystems.Suppliers;
using AccountingSystems.Web.Models.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystems.Web.Mvc.Controllers
{
    public class SupplierCreditMemoController : AccountingSystemsControllerBase
    {
        private readonly ISupplierAppService _supplierService;
        private readonly IProductAppService _productService;
        public SupplierCreditMemoController(ISupplierAppService supplierService, IProductAppService productService)
        {
            _supplierService = supplierService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CreateSupplierCreditMemo()
        {
            var suppliers = (await _supplierService.GetSupplier()).Items;
            var products = (await _productService.GetProduct()).Items;

            var model = new CreateSupplierCreditMemoViewModel
            {
                Suppliers = suppliers,
                Products = products
            };
            return View("CreateSupplierCreditMemo", model);
        }
    }
}