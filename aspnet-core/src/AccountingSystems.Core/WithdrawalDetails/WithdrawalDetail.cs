using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AccountingSystems.Products;
using AccountingSystems.WithdrawalHeaders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.WithdrawalDetails
{
    [Table("AppWithdrawalDetails")]
    public class WithdrawalDetail : FullAuditedEntity<int>, IMustHaveTenant, IPassivable
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public int WithdrawalHeaderId { get; set; }
        [ForeignKey(nameof(WithdrawalHeaderId))]
        public WithdrawalHeader  WithdrawalHeader { get; set; }
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
