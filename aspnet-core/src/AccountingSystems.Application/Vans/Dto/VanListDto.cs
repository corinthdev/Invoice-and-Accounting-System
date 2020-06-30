using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Vans.Dto
{
    public class VanListDto : EntityDto
    {
        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual string PlateNumber { get; set; }

        public virtual string District { get; set; }

        public virtual string SalesmanName { get; set; }
    }
}
