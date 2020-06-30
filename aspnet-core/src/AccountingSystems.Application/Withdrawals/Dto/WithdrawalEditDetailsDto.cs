using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Withdrawals.Dto
{
    public class WithdrawalEditDetailsDto : FullAuditedEntity<int>, IMustHaveTenant, IPassivable
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public int WithdrawalHeaderId { get; set; }
        public string WithdrawalHeaderWithdrawalCode { get; set; }
        public int ProductId { get; set; }
        public double ProductPricePerPiece { get; set; }
        public string ProductCode { get; set; }
        public string ProductItemName { get; set; }
        public int Case { get; set; }
        public int ProductCases { get; set; }
        public int Box { get; set; }
        public int ProductPieces { get; set; }
        public int Piece { get; set; }
        public int TotalPieces { get; set; }
        public double TotalProductPrice { get; set; }
        public double Gross { get; set; }
        public string Discount { get; set; }
        public double Net { get; set; }
    }
   
}
