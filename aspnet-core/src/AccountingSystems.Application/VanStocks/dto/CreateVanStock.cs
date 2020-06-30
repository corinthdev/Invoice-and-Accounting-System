using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.VanStocks.dto
{
    public class CreateVanStock
    {
        public int VanId { get; set; }
        public int ProductId { get; set; }
        public double PricePerPiece { get; set; }
        public int Case { get; set; }
        public int ProdCase { get; set; }
        public int Boxes { get; set; }
        public int ProdPiece { get; set; }
        public int Piece { get; set; }
        public int TotalPieces
        {
            get
            {
                return (Case * ProdCase) + (Boxes * ProdPiece) + Piece;
            }
        }
        public double Amount
        {
            get
            {
                return TotalPieces * PricePerPiece;
            }
        }
    }
}
