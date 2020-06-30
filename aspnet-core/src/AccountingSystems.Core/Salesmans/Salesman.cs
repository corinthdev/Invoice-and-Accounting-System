using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.Salesmans
{
    [Table("AppSalesmans")]
    public class Salesman : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Town { get; set; }

        public string Telephone { get; set; }

        public string District { get; set; }

        public string Type { get; set; }

    }
}
