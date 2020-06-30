using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingSystems.WithdrawalDetails;
using AccountingSystems.Withdrawals.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Withdrawals
{
    public class WithdrawalDetailsAppService : AsyncCrudAppService<WithdrawalDetail, WithdrawalDetailDto, int, WithdrawalDetailDto, WithdrawalDetailDto, WithdrawalDetailDto>, IWithdrawalDetailsAppService
    {
        public WithdrawalDetailsAppService(IRepository<WithdrawalDetail, int> repository) 
            : base(repository)
        {
        }
        public async override Task<WithdrawalDetailDto> CreateAsync(WithdrawalDetailDto input)
        {
            return await base.CreateAsync(input);
        }
        public async override Task DeleteAsync(EntityDto<int> input)
        {
            var details = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(details);
        }
        public async override Task<WithdrawalDetailDto> GetAsync(EntityDto<int> input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (details == null)
                return null;

            return MapToEntityDto(details);
        }

        public async Task<WithdrawalEditDetailsDto> GetDetailsAsync(int withdrawalHeaderId)
        {
            var withdrawalDetails = await Repository.FirstOrDefaultAsync(x => x.Id == withdrawalHeaderId);
            if (withdrawalDetails == null)
                return null;

            return new WithdrawalEditDetailsDto
            {
                TotalPieces = withdrawalDetails.TotalPieces
            };
        }

        public async Task<List<WithdrawalEditDetailsDto>> GetDetailsToExcel()
        {
            var details = await Repository
                .GetAllIncluding(x => x.WithdrawalHeader, y => y.Product)
                .ToListAsync();

            return new List<WithdrawalEditDetailsDto>(ObjectMapper.Map<List<WithdrawalEditDetailsDto>>(details));
        }

        public async override Task<WithdrawalDetailDto> UpdateAsync(WithdrawalDetailDto input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            ObjectMapper.Map(input, details);

            await Repository.UpdateAsync(details);
            return MapToEntityDto(details);
        }
    }
}
