using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AccountingSystems.DebitMemoDetails;
using AccountingSystems.Suppliers;
using AccountingSystems.PurchaseOrderDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.DebitMemoHeaders
{
    [Table("AppDebitMemoHeaders")]
    public class DebitMemoHeader : FullAuditedEntity<int>, IMustHaveTenant, IPassivable
    {
        [Column("DebitMemoId")]
        public override int Id { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string DebitMemoCode { get; set; }
        public string Warehouse { get; set; }
        public string SiteCode { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }
        public IEnumerable<DebitMemoDetail> DebitMemoDetails { get; set; }
        public int TotalCase { get; set; }
        public int TotalBox { get; set; }
        public int TotalPiece { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalGross { get; set; }
        public string TotalDiscount { get; set; }
        public double TotalNet { get; set; }
        public double Vatable { get; set; }
        public double TwelvePercentVat { get; set; }
        public DateTime DebitMemoDate { get; set; }
        public string CreatorUsername { get; set; }
    }
}
