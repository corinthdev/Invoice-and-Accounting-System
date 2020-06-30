using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Invoices.Dto
{
    public class InvoiceRequestDto : PagedResultRequestDto
    {
        public string InvoiceCode { get; set; }
    }
}
