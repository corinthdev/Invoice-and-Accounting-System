using AccountingSystems.Sessions.Dto;
using AccountingSystems.Suppliers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Suppliers
{
    public class PrintSupplierViewModel
    {
        public IReadOnlyList<SupplierListDto> Suppliers { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
