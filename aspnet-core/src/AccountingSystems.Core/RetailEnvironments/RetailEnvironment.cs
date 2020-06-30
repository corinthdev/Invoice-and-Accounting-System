using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.RetailEnvironments
{
    [Table("AppRetailEnvironment")]
    public class RetailEnvironment : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public string Code { get; set; }

        public string RetailEnvironmentCode { get; set; }

        public string Description { get; set; }

        public string CustomerType { get; set; }

        public string SubRECode { get; set; }
    }
}
