using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingSystems.UnloadDetails;
using AccountingSystems.Unloads.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Unloads
{
    public class UnloadDetailsAppService : AsyncCrudAppService<UnloadDetail, UnloadDetailDto, int, UnloadDetailDto, UnloadDetailDto, UnloadDetailDto>, IUnloadDetailsAppService
    {
        public UnloadDetailsAppService(IRepository<UnloadDetail, int> repository) 
            : base(repository)
        {
        }
        public async override Task<UnloadDetailDto> CreateAsync(UnloadDetailDto input)
        {
            return await base.CreateAsync(input);
        }
        public async override Task DeleteAsync(EntityDto<int> input)
        {
            var details = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(details);
        }
        public async override Task<UnloadDetailDto> GetAsync(EntityDto<int> input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (details == null)
                return null;

            return MapToEntityDto(details);
        }

        public async Task<UnloadEditDetailsDto> GetDetailsAsync(int unloadHeaderId)
        {
            var unloadDetails = await Repository.FirstOrDefaultAsync(x => x.Id == unloadHeaderId);
            if (unloadDetails == null)
                return null;

            return new UnloadEditDetailsDto
            {
                TotalPieces = unloadDetails.TotalPieces
            };
        }

        public async Task<List<UnloadEditDetailsDto>> GetDetailsToExcel()
        {
            var details = await Repository
                .GetAllIncluding(x => x.UnloadHeader, y => y.Product)
                .ToListAsync();

            return new List<UnloadEditDetailsDto>(ObjectMapper.Map<List<UnloadEditDetailsDto>>(details));
        }

        public async override Task<UnloadDetailDto> UpdateAsync(UnloadDetailDto input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            ObjectMapper.Map(input, details);

            await Repository.UpdateAsync(details);
            return MapToEntityDto(details);
        }
    }
}
