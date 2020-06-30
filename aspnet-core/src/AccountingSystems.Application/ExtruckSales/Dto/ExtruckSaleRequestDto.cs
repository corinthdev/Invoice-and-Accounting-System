using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.ExtruckSales.Dto
{
    public class ExtruckSaleRequestDto : PagedResultRequestDto
    {
        public string ExtruckSaleCode { get; set; }
    }
}
