using AccountingSystems.Sessions.Dto;
using AccountingSystems.Vans.Dto;
using AccountingSystems.VanStocks.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Vans
{
    public class PrintVanStocksViewModel
    {
        public IReadOnlyList<VanListDto> Vans { get; set; }

        public IReadOnlyList<VanStockListDto> VanStockLists { get; set; }

        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
