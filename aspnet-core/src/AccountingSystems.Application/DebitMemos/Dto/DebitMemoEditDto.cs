using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.DebitMemos.Dto
{
    public class DebitMemoEditDto : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int DebitMemoId { get; set; }
        public int TenantId { get; set; }
        public string DebitMemoCode { get; set; }
        public string Warehouse { get; set; }
        public int SupplierId { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
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
        public decimal TwelvePercentVat { get; set; }
        public DateTime DebitMemoDate { get; set; }
        public IEnumerable<DebitMemoEditDetailsDto> DebitMemoDetails { get; set; }
        public string CreatorUsername { get; set; }
    }
}
