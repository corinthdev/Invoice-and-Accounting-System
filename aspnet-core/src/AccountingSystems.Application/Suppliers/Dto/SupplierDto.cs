using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using AccountingSystems.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingSystems.Suppliers.Dto
{
    [AutoMapFrom(typeof(Supplier))]
    public class SupplierDto : EntityDto<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [Required]
        public virtual string Code { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual string Telephone { get; set; }
    }
}
