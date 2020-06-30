using Abp.Application.Services.Dto;

namespace AccountingSystems.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

