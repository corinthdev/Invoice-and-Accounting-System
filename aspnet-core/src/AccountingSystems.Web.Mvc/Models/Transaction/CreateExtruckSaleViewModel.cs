using AccountingSystems.Customers.Dto;
using AccountingSystems.Products.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Transaction
{
    public class CreateExtruckSaleViewModel
    {
        public IReadOnlyList<CustomerListDto> Customers { get; set; }

        public IReadOnlyList<ProductListDto> Products { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
