using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Customers.Dto
{
    public class CustomerListDto : EntityDto
    {
        public string Code { get; set; }

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

        public string Terms { get; set; }

        public string KindofBranch { get; set; }
    }
}
