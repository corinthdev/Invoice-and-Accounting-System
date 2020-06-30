using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Stocks.Dto
{
    [AutoMapFrom(typeof(Stock))]
    public class StockDto : FullAuditedEntityDto<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public int ProductId { get; set; }
        public double PricePerPiece { get; set; }
        public int TotalPieces { get; set; }
        public double Amount { get; set; }
        public int TotalAmount { get; set; }
    }
}
