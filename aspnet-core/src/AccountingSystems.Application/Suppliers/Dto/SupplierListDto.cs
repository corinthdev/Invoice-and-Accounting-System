using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Suppliers.Dto
{
    public class SupplierListDto : EntityDto
    {
        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual string Telephone { get; set; }
    }
}
