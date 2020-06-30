using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Salesmans.Dto
{
    public class PagedSalesmanResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
