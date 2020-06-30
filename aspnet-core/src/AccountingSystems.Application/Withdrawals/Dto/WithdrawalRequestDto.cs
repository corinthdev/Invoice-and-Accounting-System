using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Withdrawals.Dto
{
    public class WithdrawalRequestDto : PagedResultRequestDto
    {
        public string WithdrawalCode { get; set; }
    }
}
