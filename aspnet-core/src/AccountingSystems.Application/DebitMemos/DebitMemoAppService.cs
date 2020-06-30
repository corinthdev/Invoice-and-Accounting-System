using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.DebitMemoDetails;
using AccountingSystems.DebitMemoHeaders;
using AccountingSystems.DebitMemos.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.DebitMemos
{
    public class DebitMemoAppService : AsyncCrudAppService<DebitMemoHeader, DebitMemoHeaderDto, int, DebitMemoRequestDto, CreateDebitMemoDto, DebitMemoHeaderDto>, IDebitMemoAppService
    {
        private readonly IRepository<DebitMemoDetail> _debitMemoDetailRepository;
        public DebitMemoAppService(
        IRepository<DebitMemoDetail> debitMemoDetailRepository,
        IRepository<DebitMemoHeader, int> repository) 
            : base(repository)
        {
            _debitMemoDetailRepository = debitMemoDetailRepository;
        }
        public override async Task<DebitMemoHeaderDto> CreateAsync(CreateDebitMemoDto dto)
        {
            var header = await Repository.FirstOrDefaultAsync(x => x.DebitMemoCode == dto.DebitMemoCode);

            if (header != null)
                throw new UserFriendlyException("The code is already in use.");

            return await base.CreateAsync(dto);
        }

        public async Task<DebitMemoHeaderDto> GetByCodeAsync(string dto)
        {
            var result = await Repository.GetAllIncluding(x => x.Supplier)
                                         .FirstOrDefaultAsync(x => x.DebitMemoCode == dto);

            return MapToEntityDto(result);
        }
        public async Task<ListResultDto<DebitMemoListDto>> GetDebitMemo()
        {
            var debitMemos = await Repository
                .GetAll()
                .Include(x => x.Supplier)
                .ToListAsync();
            return new ListResultDto<DebitMemoListDto>(ObjectMapper.Map<List<DebitMemoListDto>>(debitMemos));
        }
        public override async Task<DebitMemoHeaderDto> UpdateAsync(DebitMemoHeaderDto dto)
        {
            var purchaseOders = new DebitMemoHeaderDto
            {
                Id = dto.DebitMemoId,
                TenantId = dto.TenantId,
                DebitMemoCode = dto.DebitMemoCode,
                SupplierId = dto.SupplierId,
                TotalCase = dto.TotalCase,
                TotalBox = dto.TotalBox,
                TotalPiece = dto.TotalPiece,
                TotalGross = dto.TotalGross,
                TotalDiscount = dto.TotalDiscount,
                TotalNet = dto.TotalNet,
                Vatable = dto.Vatable,
                TwelvePercentVat = dto.TwelvePercentVat,
                DebitMemoDate = dto.DebitMemoDate,
                CreatorUsername = dto.CreatorUsername
            };
            var header = await Repository.GetAsync(dto.DebitMemoId);

            ObjectMapper.Map(purchaseOders, header);

            await CurrentUnitOfWork.SaveChangesAsync();
            //await Repository.UpdateAsync(header);
            var output = await Repository.GetAllIncluding(x => x.Supplier)
                                         .FirstOrDefaultAsync(x => x.DebitMemoCode == dto.DebitMemoCode);
            return MapToEntityDto(output);
        }
        public async Task<LastDebitMemoCode> GetLastDebitMemoCode()
        {
            var output = await Repository
                .GetAll()
                .OrderBy(x => x.CreationTime)
                .LastOrDefaultAsync();

            var outputCode = ObjectMapper.Map<DebitMemoRequestDto>(output);

            if (output == null)
            {
                return null;
            }

            return new LastDebitMemoCode
            {
                DebitMemoCode = outputCode.DebitMemoCode
            };
        }

        public async Task<GetDebitMemoForEditOutput> GetDebitMemoForEdit(EntityDto input)
        {
            var result = new DebitMemoEditDto();
            var header = await Repository
                .GetAllIncluding(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (header != null)
            {
                ObjectMapper.Map(header, result);
                var details = await _debitMemoDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.DebitMemoHeaderId == header.Id)
                                                           .ToListAsync();

                result.DebitMemoDetails = ObjectMapper.Map<List<DebitMemoEditDetailsDto>>(details);
            }

            var debitMemoEditDto = ObjectMapper.Map<DebitMemoEditDto>(result);
            return new GetDebitMemoForEditOutput
            {
                DebitMemoEdit = debitMemoEditDto
            };
        }

        public async Task<DebitMemoEditDto> GetDebitMemoAsync(int debitMemoId)
        {
            var result = new DebitMemoEditDto();
            var debitmemo = await Repository
                .GetAllIncluding(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.Id == debitMemoId);
            if (debitmemo != null)
            {
                ObjectMapper.Map(debitmemo, result);
                var details = await _debitMemoDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.DebitMemoHeaderId == debitmemo.Id)
                                                           .ToListAsync();

                result.DebitMemoDetails = ObjectMapper.Map<List<DebitMemoEditDetailsDto>>(details);
            }

            return result;
        }

        public async Task<ListResultDto<DebitMemoListDto>> GetRecentDM()
        {
            var recent = await Repository
                .GetAllIncluding(x => x.Supplier)
                .OrderByDescending(x => x.CreationTime)
                .ToListAsync();

            var lastFive = recent.Take(5);

            return new ListResultDto<DebitMemoListDto>(ObjectMapper.Map<List<DebitMemoListDto>>(lastFive));
        }

        public async Task<List<DebitMemoEditDto>> GetHeaderToExcel()
        {
            var headers = await Repository
                .GetAllIncluding(x => x.Supplier)
                .ToListAsync();

            return new List<DebitMemoEditDto>(ObjectMapper.Map<List<DebitMemoEditDto>>(headers));
        }
    }
}
