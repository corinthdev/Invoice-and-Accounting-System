using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AccountingSystems.Salesmans;
using AccountingSystems.Vans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.Customers
{
    [Table("AppCustomers")]
    public class Customer : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public int Code { get; set; }

        public string PrincipalCode1 { get; set; }

        public string PrincipalCode2 { get; set; }
        public string Name { get; set; }

        public string HouseNumber { get; set; }

        public string Street { get; set; }

        public string Barangay { get; set; }

        public string Municipality { get; set; }

        public string Province { get; set; }

        public string ContactPerson { get; set; }

        public string Telephone { get; set; }

        [ForeignKey(nameof(SalesmansId))]
        public Salesman Salesman { get; set; }

        public int SalesmansId { get; set; }

        public string Terms { get; set; }

        public string KindofBranch { get; set; }

        public string Disc1 { get; set; }

        public string Disc2 { get; set; }

        public string Disc3 { get; set; }

        public string Disc4 { get; set; }

        public string CreditLimit { get; set; }

        public bool IsActive { get; set; }

    }
}
