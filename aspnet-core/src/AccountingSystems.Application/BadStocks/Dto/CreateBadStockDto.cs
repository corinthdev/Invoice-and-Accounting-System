using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.BadStocks.Dto
{
    public class CreateBadStockDto
    {
        public IEnumerable<CreateBadStock> Stocks { get; set; }
    }
}
