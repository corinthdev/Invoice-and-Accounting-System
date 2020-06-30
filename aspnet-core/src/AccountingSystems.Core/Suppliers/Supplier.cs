using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.Suppliers
{
    [Table("AppSuppliers")]
    public class Supplier : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

    }
}
