using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using AccountingSystems.ExtruckSaleDetails;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.ExtruckSales.Dto
{
    [AutoMapFrom(typeof(ExtruckSaleDetail))]
    public class ExtruckSaleDetailDto : FullAuditedEntityDto<int>, IMustHaveTenant, IPassivable
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public int ExtruckSaleHeaderId { get; set; }
        public int ProductId { get; set; }
        public int Case { get; set; }
        public int Box { get; set; }
        public int Piece { get; set; }
        public double TotalProductPrice { get; set; }
        public double Gross { get; set; }
        public string Discount { get; set; }
        public double Net { get; set; }
    }
}
