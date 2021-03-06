﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.CreditMemos.Dto
{
    public class CreateCreditMemoDetails
    {
        public int CreditMemoHeaderId { get; set; }
        public int ProductId { get; set; }
        public double PricePerPiece { get; set; }
        public int Case { get; set; }
        public int ProdCase { get; set; }
        public int Box { get; set; }
        public int ProdPiece { get; set; }
        public int Piece { get; set; }
        public int TotalPieces
        {
            get
            {
                return (Case * ProdCase) + (Box * ProdPiece) + Piece;
            }
        }
        public double Amount
        {
            get
            {
                return TotalPieces * PricePerPiece;
            }
        }
        public double TotalProductPrice { get; set; }
        public double Gross { get; set; }
        public string Discount { get; set; }
        public double Net { get; set; }
    }
}
