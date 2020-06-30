using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Salesmans.Dto
{
    public class SalesmanListDto : EntityDto
    {
        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual string Town { get; set; }

        public virtual string Telephone { get; set; }

        public virtual string District { get; set; }

        public virtual string Type { get; set; }
    }
}
