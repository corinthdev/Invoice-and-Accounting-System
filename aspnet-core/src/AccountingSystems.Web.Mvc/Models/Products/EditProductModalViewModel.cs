using AccountingSystems.Products.Dto;
using AccountingSystems.Suppliers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Products
{
    public class EditProductModalViewModel
    {
        public GetProductForEditOutput ProductEdit { get; set; }

        public IReadOnlyList<SupplierListDto> Suppliers { get; set; }
    }
}
