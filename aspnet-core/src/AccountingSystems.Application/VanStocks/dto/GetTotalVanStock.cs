using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.VanStocks.dto
{
    public class GetTotalVanStock
    {
        public int VanName { get; set; }
        public int AllPieces { get; set; }
        public double AllAmount { get; set; }
    }
}
