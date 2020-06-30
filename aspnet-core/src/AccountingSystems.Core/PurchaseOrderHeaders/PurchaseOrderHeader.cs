using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AccountingSystems.Suppliers;
using AccountingSystems.PurchaseOrderDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.PurchaseOrderHeaders
{
    [Table("AppPurchaseOrderHeaders")]
    public class PurchaseOrderHeader : FullAuditedEntity<int>, IMustHaveTenant, IPassivable
    {
        [Column("PurchaseOrderId")]
        public override int Id { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string PurchaseOrderCode { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }
        public IEnumerable<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public int TotalCase { get; set; }
        public int TotalBox { get; set; }
        public int TotalPiece { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalGross { get; set; }
        public string TotalDiscount { get; set; }
        public double TotalNet { get; set; }
        public double Vatable { get; set; }
        public double TwelvePercentVat { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string CreatorUsername { get; set; }
    }
}
