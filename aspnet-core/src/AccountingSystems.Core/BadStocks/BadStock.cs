using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AccountingSystems.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.BadStocks
{
    [Table("AppBadStocks")]
    public class BadStock : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int TotalPieces { get; set; }
        public double Amount { get; set; }
        public double TotalAmount { get; set; }
    }
}
