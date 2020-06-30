using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Vans.Dto
{
    public class PagedVanResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
