using Abp.AutoMapper;
using AccountingSystems.Salesmans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingSystems.Salesmans.Dto
{
    [AutoMapFrom(typeof(Salesman))]
    public class CreateSalesmanDto
    {
        [Required]
        public virtual string Code { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual string Town { get; set; }

        public virtual string Telephone { get; set; }

        public virtual string District { get; set; }

        public virtual string Type { get; set; }
    }
}
