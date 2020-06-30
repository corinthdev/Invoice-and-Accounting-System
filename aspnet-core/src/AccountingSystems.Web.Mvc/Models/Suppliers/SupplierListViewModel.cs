using AccountingSystems.Suppliers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Suppliers
{
    public class SupplierListViewModel
    {
        public IReadOnlyList<SupplierListDto> Supplier { get; set; }
    }
}
