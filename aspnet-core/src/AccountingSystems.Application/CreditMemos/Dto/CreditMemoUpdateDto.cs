using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.CreditMemos.Dto
{
    public class CreditMemoUpdateDto : FullAuditedEntityDto<int>
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }
        public bool IsGood { get; set; }
        public int CustomerId { get; set; }
        public int SalesmanId { get; set; }
        public IEnumerable<CreditMemoDetailDto> CreditMemoDetails { get; set; }
        public int TotalCase { get; set; }
        public int TotalPiece { get; set; }
        public decimal TotalCasePrice { get; set; }
        public decimal TotalPiecePrice { get; set; }
        public decimal TotalGross { get; set; }
        public string TotalDiscount { get; set; }
        public decimal TotalNet { get; set; }
        public decimal Vatable { get; set; }
        public decimal TwelvePercentVat { get; set; }
        public DateTime CreditMemoDate { get; set; }
    }
}
