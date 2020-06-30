using AccountingSystems.Customers.Dto;
using AccountingSystems.Invoices.Dto;
using AccountingSystems.LocationSites.Dto;
using AccountingSystems.Products.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Transaction
{
    public class CreateCreditMemoViewModel
    {
        public IReadOnlyList<CustomerListDto> Customers { get; set; }

        public IReadOnlyList<ProductListDto> Products { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public IReadOnlyList<InvoiceListDto> Invoices { get; set; }

        public IReadOnlyList<LocationSiteDto> LocationSites { get; set; }
    }
}
