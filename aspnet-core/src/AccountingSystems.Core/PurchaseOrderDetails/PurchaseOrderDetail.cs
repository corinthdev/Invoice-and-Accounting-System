using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AccountingSystems.Products;
using AccountingSystems.PurchaseOrderHeaders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.PurchaseOrderDetails
{
    [Table("AppPurchaseOrderDetails")]
    public class PurchaseOrderDetail : FullAuditedEntity<int>, IMustHaveTenant, IPassivable
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public int PurchaseOrderHeaderId { get; set; }
        [ForeignKey(nameof(PurchaseOrderHeaderId))]
        public PurchaseOrderHeader PurchaseOrderHeader { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int Case { get; set; }
        public int Box { get; set; }
        public int Piece { get; set; }
        public int TotalPieces { get; set; }
        public double TotalProductPrice { get; set; }
        public double Gross { get; set; }
        public string Discount { get; set; }
        public double Net { get; set; }
    }
}
