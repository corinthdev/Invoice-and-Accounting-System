using AccountingSystems.ExtruckSales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.ExtruckSales
{
    public class ExtruckSalesListViewModel
    {
        public IReadOnlyList<ExtruckSaleListDto> ExtruckSaleLists { get; set; }
    }
}
