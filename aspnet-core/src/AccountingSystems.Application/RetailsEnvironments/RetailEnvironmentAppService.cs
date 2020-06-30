using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingSystems.RetailEnvironments;
using AccountingSystems.RetailsEnvironments.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.RetailsEnvironments
{
    public class RetailEnvironmentAppService : AsyncCrudAppService<RetailEnvironment, RetailEnvironmentDto, int, PagedRetailEnvironmentResultRequestDto, CreateRetailEnvironmentDto, RetailEnvironmentDto>, IRetailEnvironmentAppService
    {
        public RetailEnvironmentAppService(IRepository<RetailEnvironment, int> repository) 
            : base(repository)
        {
        }

        public override async Task<RetailEnvironmentDto> CreateAsync(CreateRetailEnvironmentDto input)
        {
            var retailenv = ObjectMapper.Map<RetailEnvironment>(input);
            await Repository.InsertAsync(retailenv);
            return MapToEntityDto(retailenv);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var retailenv = await Repository.GetAsync(input.Id);
            await Repository.DeleteAsync(retailenv);
        }

        public override async Task<RetailEnvironmentDto> GetAsync(EntityDto<int> input)
        {
            var retailenv = await Repository.GetAsync(input.Id);
            return MapToEntityDto(retailenv);
        }

        public async Task<ListResultDto<RetailEnvironmentListDto>> GetRetailEnvironment()
        {
            var retailenv = await Repository
                .GetAllListAsync();
            return new ListResultDto<RetailEnvironmentListDto>(ObjectMapper.Map<List<RetailEnvironmentListDto>>(retailenv));
        }

        public async Task<GetRetailEnvironmentForEditOutput> GetRetailEnvironmentForEdit(EntityDto input)
        {
            var retailenv = await Repository
                .GetAll()
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            var retailEnvDto = ObjectMapper.Map<RetailEnvironmentEditDto>(retailenv);
            return new GetRetailEnvironmentForEditOutput
            {
                EnvironmentEdit = retailEnvDto
            };
        }

        public async Task<List<RetailEnvironmentListDto>> GetRetailEnvironmentToExcel()
        {
            var retailenvs = await Repository.GetAllListAsync();
            return new List<RetailEnvironmentListDto>(ObjectMapper.Map<List<RetailEnvironmentListDto>>(retailenvs));
        }

        public override async  Task<RetailEnvironmentDto> UpdateAsync(RetailEnvironmentDto input)
        {
            var retailenv = await Repository.GetAsync(input.Id);
            ObjectMapper.Map(input, retailenv);
            await Repository.UpdateAsync(retailenv);
            return MapToEntityDto(retailenv);
        }
    }
}
