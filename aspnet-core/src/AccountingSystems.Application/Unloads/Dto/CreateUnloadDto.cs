using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Unloads.Dto
{
    public class CreateUnloadDto : FullAuditedEntityDto<int>
    {
        public int UnloadId { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string UnloadCode { get; set; }
        public int VanId { get; set; }
        public int SalesmanId { get; set; }
        public IEnumerable<CreateUnloadDetails> UnloadDetails { get; set; }
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
        public DateTime UnloadDate { get; set; }
        public string CreatorUsername { get; set; }
    }
}
