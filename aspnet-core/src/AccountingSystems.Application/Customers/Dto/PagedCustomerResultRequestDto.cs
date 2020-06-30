using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Customers.Dto
{
    public class PagedCustomerResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
