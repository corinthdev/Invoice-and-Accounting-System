using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.Vans.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Vans
{
    public interface IVanAppService : IAsyncCrudAppService<VanDto, int, PagedVanResultRequestDto, CreateVanDto, VanDto>
    {
        Task<ListResultDto<VanListDto>> GetVan();
        Task<GetVanForEditOutput> GetVanForEdit(EntityDto input);
        Task<GetVanNameForOutput> GetVAnName(string vanCode);
        Task<List<VanListDto>> GetVanToExcel();
    }
}
