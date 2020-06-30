using AccountingSystems.Customers.Dto;
using AccountingSystems.Products.Dto;
using AccountingSystems.Sessions.Dto;
using AccountingSystems.Suppliers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Transaction
{
    public class CreateSupplierCreditMemoViewModel
    {
        public IReadOnlyList<SupplierListDto> Suppliers { get; set; }

        public IReadOnlyList<ProductListDto> Products { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
