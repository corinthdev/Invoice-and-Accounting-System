using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.PurchaseOrders.Dto
{
    public class PurchaseOrderDetailDto : FullAuditedEntityDto<int>, IMustHaveTenant, IPassivable
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public int PurchaseOrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public double PricePerPiece { get; set; }
        public int Case { get; set; }
        public int ProdCase { get; set; }
        public int Box { get; set; }
        public int ProdPiece { get; set; }
        public int Piece { get; set; }
        public double TotalProductPrice { get; set; }
        public double Gross { get; set; }
        public string Discount { get; set; }
        public double Net { get; set; }
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
    }
}
