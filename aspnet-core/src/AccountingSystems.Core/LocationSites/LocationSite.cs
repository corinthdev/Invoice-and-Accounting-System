using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.Sites
{
    [Table("AppLocationSites")]
    public class LocationSite : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }
        public string SiteCode { get; set; }
        public string Description { get; set; }
    }
}
