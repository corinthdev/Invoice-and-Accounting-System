using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AccountingSystems.Controllers;
using System.Threading.Tasks;
using AccountingSystems.Stocks;
using AccountingSystems.BadStocks;
using AccountingSystems.Web.Models.HomePage;
using AccountingSystems.Salesmans;
using AccountingSystems.Suppliers;
using AccountingSystems.Customers;
using AccountingSystems.Products;
using AccountingSystems.Invoices;
using AccountingSystems.CreditMemos;
using AccountingSystems.DebitMemos;
using AccountingSystems.PurchaseOrders;
using AccountingSystems.Vans;
using AccountingSystems.VanStocks;
using AccountingSystems.VanStocks.dto;
using System.Collections.Generic;
using AccountingSystems.Sessions;

namespace AccountingSystems.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IStockAppService _stockService;
        private readonly IBadStockAppService _badStockService;
        private readonly ISalesmanAppService _salesmaService;
        private readonly ISupplierAppService _supplierService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IProductAppService _productAppService;
        private readonly IInvoiceAppService _invoiceAppService;
        private readonly ICreditMemoAppService _creditMemoAppService;
        private readonly IDebitMemoAppService _debitMemoAppService;
        private readonly IPurchaseOrderAppService _purchaseOrderAppService;
        private readonly IVanAppService _vanAppService;
        private readonly IVanStockAppService _vanStockAppService;

        public HomeController(ISessionAppService sessionAppService,
                              IStockAppService stockService,
                              IBadStockAppService badStockService,
                              ISalesmanAppService salesmaService,
                              ISupplierAppService supplierService,
                              ICustomerAppService customerAppService,
                              IProductAppService productAppService,
                              IInvoiceAppService invoiceAppService,
                              ICreditMemoAppService creditMemoAppService,
                              IDebitMemoAppService debitMemoAppService,
                              IPurchaseOrderAppService purchaseOrderAppService,
                              IVanAppService vanAppService,
                              IVanStockAppService vanStockAppService
                             )
        {
            _sessionAppService = sessionAppService;
            _stockService = stockService;
            _badStockService = badStockService;
            _salesmaService = salesmaService;
            _supplierService = supplierService;
            _customerAppService = customerAppService;
            _productAppService = productAppService;
            _invoiceAppService = invoiceAppService;
            _creditMemoAppService = creditMemoAppService;
            _debitMemoAppService = debitMemoAppService;
            _purchaseOrderAppService = purchaseOrderAppService;
            _vanAppService = vanAppService;
            _vanStockAppService = vanStockAppService;
        }
        public async Task<ActionResult> Index()
        {
            List<GetTotal> list = new List<GetTotal>();
            var stocks = await _stockService.GetTotal();
            var badStocks = await _badStockService.GetTotal();
            var salesman = await _salesmaService.GetTotalSalesman();
            var supplier = await _supplierService.GetTotalSupplier();
            var customer = await _customerAppService.GetTotalCustomer();
            var products = await _productAppService.GetTotalProduct();
            var invoices = (await _invoiceAppService.GetRecentInvoice()).Items;
            var creditMemos = (await _creditMemoAppService.GetRecentCM()).Items;
            var debitMemos = (await _debitMemoAppService.GetRecentDM()).Items;
            var purchaseOrders = (await _purchaseOrderAppService.GetrecentPurchase()).Items;
            var vans = (await _vanAppService.GetVan()).Items;
            
            foreach(var items in vans)
            {
                var total = await _vanStockAppService.GetTotal(items.Id);
                list.Add(total);
            }
            var model = new HomeViewModel
            {
                TotalStocks = stocks,
                BadStocks = badStocks,
                Salesman = salesman,
                Suppliers = supplier,
                Customers = customer,
                Products = products,
                InvoiceLists = invoices,
                CreditMemos = creditMemos,
                DebitMemos = debitMemos,
                PurchaseOrders = purchaseOrders,
                Vans = vans,
                VanStocks = list,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };
            return View(model);
        }
	}
}
