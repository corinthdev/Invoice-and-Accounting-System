using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.Unloads.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Unloads
{
    public interface IUnloadAppService : IAsyncCrudAppService<UnloadHeaderDto, int, UnloadHeaderDto, CreateUnloadDto, UnloadHeaderDto>
    {
        Task<ListResultDto<UnloadListDto>> GetUnload();
        Task<LastUnloadCode> GetLastUnloadCode();
        Task<GetUnloadForEditOutput> GetUnloadForEdit(EntityDto input);
        Task<UnloadEditDto> GetUnloadAsync(int withdrawalId);
        Task<List<UnloadEditDto>> GetHeaderToExcel();
    }
}
