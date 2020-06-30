using AccountingSystems.BadStocks.Dto;
using AccountingSystems.CreditMemos.Dto;
using AccountingSystems.Customers.Dto;
using AccountingSystems.DebitMemos.Dto;
using AccountingSystems.Invoices.Dto;
using AccountingSystems.Products.Dto;
using AccountingSystems.PurchaseOrders.Dto;
using AccountingSystems.Salesmans.Dto;
using AccountingSystems.Sessions.Dto;
using AccountingSystems.Stocks.Dto;
using AccountingSystems.Suppliers.Dto;
using AccountingSystems.Vans.Dto;
using AccountingSystems.VanStocks.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.HomePage
{
    public class HomeViewModel
    {
        public GetTotalStocks TotalStocks { get; set; }
        public GetTotalBadStocks BadStocks { get; set; }
        public GetTotalSalesman Salesman { get; set; }
        public GetTotalSupplier Suppliers { get; set; }
        public GetTotalCustomer Customers { get; set; }
        public GetTotalProduct Products { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
        public IReadOnlyList<InvoiceListDto> InvoiceLists { get; set; }
        public IReadOnlyList<CreditMemoListDto> CreditMemos { get; set; }
        public IReadOnlyList<DebitMemoListDto> DebitMemos { get; set; }
        public IReadOnlyList<PurchaseOrderListDto> PurchaseOrders { get; set; }
        public IReadOnlyList<VanListDto> Vans { get; set; }
        public IReadOnlyList<GetTotal> VanStocks { get; set; }
    }
}
