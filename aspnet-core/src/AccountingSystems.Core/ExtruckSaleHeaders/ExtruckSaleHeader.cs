using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AccountingSystems.Customers;
using AccountingSystems.ExtruckSaleDetails;
using AccountingSystems.Salesmans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.ExtruckSaleHeaders
{
    [Table("AppExtruckSaleHeaders")]
    public class ExtruckSaleHeader : FullAuditedEntity<int>, IMustHaveTenant, IPassivable
    {
        [Column("ExtruckSaleId")]
        public override int Id { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string ExtruckSaleCode { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public int SalesmanId { get; set; }
        [ForeignKey(nameof(SalesmanId))]
        public Salesman Salesman { get; set; }
        public IEnumerable<ExtruckSaleDetail> ExtruckSaleDetails { get; set; }
        public int TotalCase { get; set; }
        public int TotalBox { get; set; }
        public int TotalPiece { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalGross { get; set; }
        public string TotalDiscount { get; set; }
        public double TotalNet { get; set; }
        public double Vatable { get; set; }
        public double TwelvePercentVat { get; set; }
        public DateTime ExtruckSaleDate { get; set; }
        public string CreatorUsername { get; set; }
    }
}
