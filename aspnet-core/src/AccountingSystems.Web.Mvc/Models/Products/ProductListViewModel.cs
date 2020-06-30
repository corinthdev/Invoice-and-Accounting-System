using AccountingSystems.Products.Dto;
using AccountingSystems.Suppliers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Products
{
    public class ProductListViewModel
    {
        public IReadOnlyList<ProductListDto> ProductLists { get; set; }

        public IReadOnlyList<SupplierListDto> SupplierLists { get; set; }
    }
}
