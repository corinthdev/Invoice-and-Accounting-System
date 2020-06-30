using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingSystems.WithdrawalDetails;
using AccountingSystems.WithdrawalHeaders;
using AccountingSystems.Withdrawals.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Withdrawals
{
    public class WithdrawalAppService : AsyncCrudAppService<WithdrawalHeader, WithdrawalHeaderDto, int, WithdrawalHeaderDto, CreateWithdrawalDto, WithdrawalHeaderDto>, IWithdrawalAppService
    {
        private readonly IRepository<WithdrawalDetail> _withdrawalDetailRepository;
        public WithdrawalAppService(
        IRepository<WithdrawalDetail> withdrawalDetailRepository,
        IRepository<WithdrawalHeader, int> repository) 
            : base(repository)
        {
            _withdrawalDetailRepository = withdrawalDetailRepository;
        }
        public async override Task<WithdrawalHeaderDto> CreateAsync(CreateWithdrawalDto input)
        {
            return await base.CreateAsync(input);
        }

        public async Task<List<WithdrawalEditDto>> GetHeaderToExcel()
        {
            var headers = await Repository
                .GetAllIncluding(x => x.Van, y => y.Salesman)
                .ToListAsync();

            return new List<WithdrawalEditDto>(ObjectMapper.Map<List<WithdrawalEditDto>>(headers));
        }

        public async Task<LastWithdrawalCode> GetLastWithdrawalCode()
        {
            var output = await Repository
               .GetAll()
               .OrderBy(x => x.CreationTime)
               .LastOrDefaultAsync();

            var outputCode = ObjectMapper.Map<WithdrawalRequestDto>(output);

            if (output == null)
                return null;

            return new LastWithdrawalCode
            {
                WithdrawalCode = outputCode.WithdrawalCode
            };
        }

        public async Task<ListResultDto<WithdrawalListDto>> GetWithdrawal()
        {
            var withdrawal = await Repository
                .GetAll()
                .Include(x => x.Van)
                .Include(y => y.Salesman)
                .ToListAsync();
            return new ListResultDto<WithdrawalListDto>(ObjectMapper.Map<List<WithdrawalListDto>>(withdrawal));
        }

        public async Task<WithdrawalEditDto> GetWithdrawalAsync(int withdrawalId)
        {
            var result = new WithdrawalEditDto();
            var header = await Repository
                .GetAllIncluding(x => x.Van, x => x.Salesman)
                .FirstOrDefaultAsync(x => x.Id == withdrawalId);
            if (header != null)
            {
                ObjectMapper.Map(header, result);
                var details = await _withdrawalDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.WithdrawalHeaderId == header.Id)
                                                           .ToListAsync();

                result.WithdrawalDetails = ObjectMapper.Map<List<WithdrawalEditDetailsDto>>(details);
            }

            return result;
        }

        public async Task<GetWithdrawalForEditOutput> GetWithdrawalForEdit(EntityDto input)
        {
            var result = new WithdrawalEditDto();
            var header = await Repository
                .GetAllIncluding(x => x.Van, x => x.Salesman)
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (header != null)
            {
                ObjectMapper.Map(header, result);
                var details = await _withdrawalDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.WithdrawalHeaderId == header.Id)
                                                           .ToListAsync();

                result.WithdrawalDetails = ObjectMapper.Map<List<WithdrawalEditDetailsDto>>(details);
            }

            var dto = ObjectMapper.Map<WithdrawalEditDto>(result);
            return new GetWithdrawalForEditOutput
            {
                WithdrawalEdit = dto
            };
        }
        public async override Task<WithdrawalHeaderDto> UpdateAsync(WithdrawalHeaderDto dto)
        {
            var withdrawals = new WithdrawalHeaderDto
            {
                Id = dto.WithdrawalId,
                TenantId = dto.TenantId,
                WithdrawalCode = dto.WithdrawalCode,
                VanId = dto.VanId,
                SalesmanId = dto.SalesmanId,
                TotalCase = dto.TotalCase,
                TotalBox = dto.TotalBox,
                TotalPiece = dto.TotalPiece,
                TotalGross = dto.TotalGross,
                TotalDiscount = dto.TotalDiscount,
                TotalNet = dto.TotalNet,
                Vatable = dto.Vatable,
                TwelvePercentVat = dto.TwelvePercentVat,
                WithdrawalDate = dto.WithdrawalDate,
                CreatorUsername = dto.CreatorUsername
            };
            var header = await Repository.GetAsync(dto.WithdrawalId);
            ObjectMapper.Map(withdrawals, header);

            await CurrentUnitOfWork.SaveChangesAsync();
            //await Repository.UpdateAsync(header);
            var output = await Repository.GetAllIncluding(x => x.Van, x => x.Salesman)
                                         .FirstOrDefaultAsync(x => x.WithdrawalCode == dto.WithdrawalCode);
            return MapToEntityDto(output);
        }
    }
}
