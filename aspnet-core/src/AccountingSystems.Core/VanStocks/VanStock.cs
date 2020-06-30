using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AccountingSystems.Products;
using AccountingSystems.Vans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.VanStocks
{
    [Table("AppVanStocks")]
    public class VanStock : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int TotalPieces { get; set; }
        public double Amount { get; set; }
        public double TotalAmount { get; set; }
        public int VanId { get; set; }
        [ForeignKey(nameof(VanId))]
        public Van Van { get; set; }
    }
}
