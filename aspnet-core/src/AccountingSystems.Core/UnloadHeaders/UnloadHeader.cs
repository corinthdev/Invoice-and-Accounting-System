using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AccountingSystems.Salesmans;
using AccountingSystems.UnloadDetails;
using AccountingSystems.Vans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.UnloadHeaders
{
    [Table("AppUnloadHeaders")]
    public class UnloadHeader : FullAuditedEntity<int>, IMustHaveTenant, IPassivable
    {
        [Column("UnloadId")]
        public override int Id { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string UnloadCode { get; set; }
        public int VanId { get; set; }
        [ForeignKey(nameof(VanId))]
        public Van Van { get; set; }
        public int SalesmanId { get; set; }
        [ForeignKey(nameof(SalesmanId))]
        public Salesman Salesman { get; set; }
        public IEnumerable<UnloadDetail> UnloadDetails { get; set; }
        public int TotalCase { get; set; }
        public int TotalBox { get; set; }
        public int TotalPiece { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalGross { get; set; }
        public string TotalDiscount { get; set; }
        public double TotalNet { get; set; }
        public double Vatable { get; set; }
        public double TwelvePercentVat { get; set; }
        public DateTime UnloadDate { get; set; }
        public string CreatorUsername { get; set; }
    }
}
