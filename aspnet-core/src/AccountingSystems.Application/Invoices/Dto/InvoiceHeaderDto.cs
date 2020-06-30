using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AccountingSystems.InvoiceHeaders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Invoices.Dto
{
    [AutoMapFrom(typeof(InvoiceHeader))]
    public class InvoiceHeaderDto : FullAuditedEntityDto<int>
    {
        public int InvoiceId { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string InvoiceCode { get; set; }
        public int CustomerId { get; set; }
        public int SalesmanId { get; set; }
        public IEnumerable<InvoiceDetailDto> InvoiceDetails { get; set; }
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
        public DateTime InvoiceDate { get; set; }
        public string CreatorUsername { get; set; }
        public string EditorUsername { get; set; }
    }
}
