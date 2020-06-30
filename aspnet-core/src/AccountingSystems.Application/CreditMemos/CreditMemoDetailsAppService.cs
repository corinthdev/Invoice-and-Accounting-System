using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingSystems.CreditMemoDetails;
using AccountingSystems.CreditMemos.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.CreditMemos
{
    public class CreditMemoDetailsAppService : AsyncCrudAppService<CreditMemoDetail, CreditMemoDetailDto, int, CreditMemoDetailDto, CreditMemoDetailDto, CreditMemoDetailDto>, ICreditMemoDetailsAppService
    {
        public CreditMemoDetailsAppService(IRepository<CreditMemoDetail, int> repository) 
            : base(repository)
        {
        }
        public async override Task<CreditMemoDetailDto> CreateAsync(CreditMemoDetailDto input)
        {
            return await base.CreateAsync(input);
        }
        public async override Task DeleteAsync(EntityDto<int> input)
        {
            var details = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(details);
        }
        public async override Task<CreditMemoDetailDto> GetAsync(EntityDto<int> input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (details == null)
                return null;

            return MapToEntityDto(details);
        }
        public async Task<CreditMemoEditDetailsDto> GetDetailsAsync(int creditMemoHeaderId)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == creditMemoHeaderId);
            if (details == null)
                return null;

            return new CreditMemoEditDetailsDto
            {
                TotalPieces = details.TotalPieces
            };
        }

        public async Task<List<CreditMemoEditDetailsDto>> GetDetailsToExcel()
        {
            var details = await Repository
                .GetAllIncluding(x => x.CreditMemoHeader, y => y.Product)
                .ToListAsync();

            return new List<CreditMemoEditDetailsDto>(ObjectMapper.Map<List<CreditMemoEditDetailsDto>>(details));
        }

        public async override Task<CreditMemoDetailDto> UpdateAsync(CreditMemoDetailDto input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            ObjectMapper.Map(input, details);

            await Repository.UpdateAsync(details);
            return MapToEntityDto(details);
        }
    }
}
