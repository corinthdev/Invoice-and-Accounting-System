using AccountingSystems.BadStocks.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.BadStock
{
    public class BadStockListViewModel
    {
        public IReadOnlyList<BadStockListDto> StockListDtos { get; set; }
        public GetTotalBadStocks Total { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
        public IReadOnlyList<string> ProductBrands { get; set; }
    }
}
