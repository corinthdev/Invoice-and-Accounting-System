using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AccountingSystems.ExtruckSaleHeaders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.ExtruckSales.Dto
{
    [AutoMapFrom(typeof(ExtruckSaleHeader))]
    public class ExtruckHeaderDto : FullAuditedEntityDto<int>
    {
        public int ExtruckSaleId { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string ExtruckSaleCode { get; set; }
        public int CustomerId { get; set; }
        public int SalesmanId { get; set; }
        public IEnumerable<ExtruckSaleDetailDto>  ExtruckSaleDetails { get; set; }
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
        public decimal TotalGross { get; set; }
        public string TotalDiscount { get; set; }
        public decimal TotalNet { get; set; }
        public decimal Vatable { get; set; }
        public decimal TwelvePercentVat { get; set; }
        public DateTime ExtruckSaleDate { get; set; }
        public string CreatorUsername { get; set; }
    }
}
