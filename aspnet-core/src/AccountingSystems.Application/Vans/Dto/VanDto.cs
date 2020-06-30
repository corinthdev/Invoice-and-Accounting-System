using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AccountingSystems.Vans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingSystems.Vans.Dto
{
    [AutoMapFrom(typeof(Van))]
    public class VanDto : EntityDto<int>
    {
        [Required]
        public virtual string Code { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string PlateNumber { get; set; }

        public virtual string District { get; set; }

        public virtual int SalesmanId { get; set; }

        public string SalesmanCode { get; set; }

        public string SalesmanName { get; set; }

    }
}
