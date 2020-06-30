using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.VanStocks.dto
{
    public class VanStockListDto
    {
        public string VanName { get; set; }
        public string ProductCode { get; set; }
        public string ProductItemName { get; set; }
        public string ProductBrand { get; set; }
        public int TotalPieces { get; set; }
        public double ProductPricePerPiece { get; set; }
        public double Amount { get; set; }
    }
}
