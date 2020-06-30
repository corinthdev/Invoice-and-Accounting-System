using Abp.AutoMapper;
using AccountingSystems.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingSystems.Suppliers.Dto
{
    [AutoMapFrom(typeof(Supplier))]
    public class CreateSupplierDto
    {
        [Required]
        public virtual string Code { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual string Telephone { get; set; }
    }
}
