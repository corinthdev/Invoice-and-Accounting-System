using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingSystems.Customers.Dto
{
    public class CustomerEditDto : EntityDto<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public string PrincipalCode1 { get; set; }

        [Required]
        public string PrincipalCode2 { get; set; }

        [Required]
        public string Name { get; set; }

        public string HouseNumber { get; set; }

        public string Street { get; set; }

        public string Barangay { get; set; }

        public string Municipality { get; set; }

        public string Province { get; set; }

        public string ContactPerson { get; set; }

        public string Telephone { get; set; }

        public int SalesmansId { get; set; }

        public string SalesmanCode { get; set; }

        public string SalesmanName { get; set; }

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
