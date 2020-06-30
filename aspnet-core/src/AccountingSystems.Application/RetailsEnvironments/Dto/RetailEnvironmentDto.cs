using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.RetailsEnvironments.Dto
{
    public class RetailEnvironmentDto : EntityDto<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }
         
        public string Code { get; set; }

        public string RetailEnvironmentCode { get; set; }

        public string Description { get; set; }

        public string CustomerType { get; set; }

        public string SubRECode { get; set; }
    }
}
