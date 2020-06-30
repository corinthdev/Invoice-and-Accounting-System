using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Stocks.Dto
{
    public class CreateStockDto
    {
        public IEnumerable<CreateStock> Stocks { get; set; }
    }
}
