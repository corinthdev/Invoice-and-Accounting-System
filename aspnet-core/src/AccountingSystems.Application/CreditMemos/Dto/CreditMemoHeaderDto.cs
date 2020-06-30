using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.CreditMemos.Dto
{
    public class CreditMemoHeaderDto : FullAuditedEntityDto<int>
    {
        public int CreditMemoId { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string CreditMemoCode { get; set; }
        public string CreditMemoMode { get; set; }
        public string SiteCode { get; set; }
        public string ReferenceInvoiceCode { get; set; }
        public bool IsGood { get; set; }
        public int CustomerId { get; set; }
        public int SalesmanId { get; set; }
        public IEnumerable<CreditMemoDetailDto> CreditMemoDetails { get; set; }
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
        public DateTime CreditMemoDate { get; set; }
        public string CreatorUsername { get; set; }
    }
}
