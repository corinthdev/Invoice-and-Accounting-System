using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingSystems.DebitMemoDetails;
using AccountingSystems.DebitMemos.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.DebitMemos
{
    public class DebitMemoDetailsAppService : AsyncCrudAppService<DebitMemoDetail, DebitMemoDetailDto, int, DebitMemoDetailDto, DebitMemoDetailDto, DebitMemoDetailDto>, IDebitMemoDetailsAppService
    {
        public DebitMemoDetailsAppService(IRepository<DebitMemoDetail, int> repository) 
            : base(repository)
        {
        }
        public async override Task<DebitMemoDetailDto> CreateAsync(DebitMemoDetailDto input)
        {
            return await base.CreateAsync(input);
        }
        public async override Task DeleteAsync(EntityDto<int> input)
        {
            var details = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(details);
        }
        public async override Task<DebitMemoDetailDto> GetAsync(EntityDto<int> input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (details == null)
                return null;

            return MapToEntityDto(details);
        }
        public async Task<DebitMemoEditDetailsDto> GetDetailsAsync(int creditMemoHeaderId)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == creditMemoHeaderId);
            if (details == null)
                return null;

            return new DebitMemoEditDetailsDto
            {
                TotalPieces = details.TotalPieces
            };
        }

        public async Task<List<DebitMemoEditDetailsDto>> GetDetailsToExcel()
        {
            var details = await Repository
                .GetAllIncluding(x => x.DebitMemoHeader, y => y.Product)
                .ToListAsync();

            return new List<DebitMemoEditDetailsDto>(ObjectMapper.Map<List<DebitMemoEditDetailsDto>>(details));
        }

        public async override Task<DebitMemoDetailDto> UpdateAsync(DebitMemoDetailDto input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            ObjectMapper.Map(input, details);

            await Repository.UpdateAsync(details);
            return MapToEntityDto(details);
        }
    }
}
