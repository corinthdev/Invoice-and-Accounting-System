using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Withdrawals.Dto
{
    public class CreateWithdrawalDto : FullAuditedEntityDto<int>
    {
        public int WithdrawalId { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string WithdrawalCode { get; set; }
        public int VanId { get; set; }
        public int SalesmanId { get; set; }
        public IEnumerable<CreateWithdrawalDetails> WithdrawalDetails { get; set; }
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
        public double TotalGross { get; set; }
        public string TotalDiscount { get; set; }
        public double TotalNet { get; set; }
        public double Vatable { get; set; }
        public double TwelvePercentVat { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public string CreatorUsername { get; set; }
    }
}
