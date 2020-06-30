using Abp.Application.Services;
using AccountingSystems.Unloads.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Unloads
{
    public interface IUnloadDetailsAppService : IAsyncCrudAppService<UnloadDetailDto, int, UnloadDetailDto, UnloadDetailDto, UnloadDetailDto>
    {
        Task<UnloadEditDetailsDto> GetDetailsAsync(int unloadHeaderId);
        Task<List<UnloadEditDetailsDto>> GetDetailsToExcel();
    }
}
