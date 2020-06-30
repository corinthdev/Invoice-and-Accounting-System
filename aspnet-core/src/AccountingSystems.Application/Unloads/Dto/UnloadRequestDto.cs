using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Unloads.Dto
{
    public class UnloadRequestDto : PagedResultRequestDto
    {
        public string UnloadCode { get; set; }
    }
}
