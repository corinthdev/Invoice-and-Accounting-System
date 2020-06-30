using AccountingSystems.Products.Dto;
using AccountingSystems.Sessions.Dto;
using AccountingSystems.Stocks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Stocks
{
    public class StockListViewModel
    {
        public IReadOnlyList<ProductListDto> ProductLists { get; set; }
        public IReadOnlyList<StockListDto> StockLists { get; set; }
        public GetTotalStocks Total { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
        public IReadOnlyList<string> ProductBrands { get; set; }
    }
}
