using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.VanStocks.dto
{
    public class VanStockDto : FullAuditedEntityDto<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int ProductId { get; set; }
        public double PricePerPiece { get; set; }
        public int TotalPieces { get; set; }
        public double Amount { get; set; }
        public int TotalAmount { get; set; }
        public int VanId { get; set; }
    }
}
