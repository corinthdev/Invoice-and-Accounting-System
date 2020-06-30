using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AccountingSystems.Controllers;
using AccountingSystems.Customers;
using AccountingSystems.ExtruckSales;
using AccountingSystems.Products;
using AccountingSystems.Sessions;
using AccountingSystems.Web.Models.ExtruckSales;
using AccountingSystems.Web.Models.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystems.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ExtruckSalesController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly ICustomerAppService _customerService;
        private readonly IProductAppService _productService;
        private readonly IExtruckSaleAppService _extruckSaleService;
        public ExtruckSalesController(ISessionAppService sessionAppService,
                                      ICustomerAppService customerService,
                                      IProductAppService productService,
                                      IExtruckSaleAppService extruckSaleService
                                     )
        {
            _sessionAppService = sessionAppService;
            _customerService = customerService;
            _productService = productService;
            _extruckSaleService = extruckSaleService;
        }
        public async Task<ActionResult> Index()
        {
            var extruckSales = (await _extruckSaleService.GetExtruckSale()).Items;
            var model = new ExtruckSalesListViewModel
            {
                ExtruckSaleLists = extruckSales
            };
            return View(model);
        }
        public async Task<ActionResult> Create()
        {
            var customers = (await _customerService.GetCustomer()).Items;
            var products = (await _productService.GetProduct()).Items;

            var model = new CreateExtruckSaleViewModel
            {
                Customers = customers,
                Products = products,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
            };
            return View("Create", model);
        }
        public async Task<ActionResult> View(int extruckId)
        {
            var extruckSales = await _extruckSaleService.GetExtruckSaleForEdit(new EntityDto(extruckId));
            var model = ObjectMapper.Map<ViewExtruckSaleViewModel>(extruckSales);
            return View("View", model);
        }
        public async Task<ActionResult> Print(int extruckId)
        {
            var extruckSales = await _extruckSaleService.GetExtruckSaleForEdit(new EntityDto(extruckId));
            var model = ObjectMapper.Map<ViewExtruckSaleViewModel>(extruckSales);
            return View("Print", model);
        }
        public async Task<ActionResult> Edit(int extruckId)
        {
            var extruckSales = await _extruckSaleService.GetExtruckSaleForEdit(new EntityDto(extruckId));
            var model = ObjectMapper.Map<EditExtruckSaleViewModel>(extruckSales);
            return View("Edit", model);
        }
    }
}