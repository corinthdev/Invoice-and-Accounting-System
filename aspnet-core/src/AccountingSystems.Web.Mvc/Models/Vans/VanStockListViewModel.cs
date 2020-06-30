using AccountingSystems.VanStocks.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Vans
{
    public class VanStockListViewModel
    {
        public IReadOnlyList<VanStockListDto> VanStockLists { get; set; }
        public GetTotal Total { get; set; }
    }
}
