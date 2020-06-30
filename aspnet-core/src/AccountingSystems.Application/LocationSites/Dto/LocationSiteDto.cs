using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AccountingSystems.Sites;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.LocationSites.Dto
{
    [AutoMapFrom(typeof(LocationSite))]
    public class LocationSiteDto : FullAuditedEntityDto<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public string SiteCode { get; set; }
        public string Description { get; set; }
    }
}
