using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.CreditMemos.Dto
{
    public class CreditMemoRequestDto : PagedResultRequestDto
    {
        public string CreditMemoCode { get; set; }
    }
}
