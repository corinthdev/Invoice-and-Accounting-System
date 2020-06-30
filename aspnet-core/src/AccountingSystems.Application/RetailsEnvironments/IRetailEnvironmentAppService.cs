using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.RetailsEnvironments.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.RetailsEnvironments
{
    public interface IRetailEnvironmentAppService : IAsyncCrudAppService<RetailEnvironmentDto, int, PagedRetailEnvironmentResultRequestDto, CreateRetailEnvironmentDto, RetailEnvironmentDto>
    {
        Task<ListResultDto<RetailEnvironmentListDto>> GetRetailEnvironment();
        Task<GetRetailEnvironmentForEditOutput> GetRetailEnvironmentForEdit(EntityDto input);
        Task<List<RetailEnvironmentListDto>> GetRetailEnvironmentToExcel();
    }
}
