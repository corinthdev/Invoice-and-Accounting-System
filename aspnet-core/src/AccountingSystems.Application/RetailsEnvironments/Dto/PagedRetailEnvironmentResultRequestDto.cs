using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.RetailsEnvironments.Dto
{
    public class PagedRetailEnvironmentResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
