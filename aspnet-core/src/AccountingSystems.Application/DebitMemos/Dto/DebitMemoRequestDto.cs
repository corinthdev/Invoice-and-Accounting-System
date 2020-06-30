using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.DebitMemos.Dto
{
    public class DebitMemoRequestDto : PagedResultRequestDto
    {
        public string DebitMemoCode { get; set; }
    }
}
