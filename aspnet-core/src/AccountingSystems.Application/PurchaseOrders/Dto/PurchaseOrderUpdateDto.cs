using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.PurchaseOrders.Dto
{
    public class PurchaseOrderUpdateDto
    {
        public int PurchaseOrderId { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string PurchaseOrderCode { get; set; }
        public int CustomerId { get; set; }
        public int SalesmanId { get; set; }
        public IEnumerable<PurchaseOrderDetailDto> PurchaseOrderDetails { get; set; }
        public int TotalCase { get; set; }
        public int TotalBox { get; set; }
        public int TotalPiece { get; set; }
        public int TotalQuantity
        {
            get
            {
                return TotalCase + TotalBox + TotalPiece;
            }
        }
        public decimal TotalGross { get; set; }
        public string TotalDiscount { get; set; }
        public decimal TotalNet { get; set; }
        public decimal Vatable { get; set; }
        public decimal TwelvePercentVat { get; set; }
        public DateTime PurchaseOrderDate { get; set; }
    }
}
