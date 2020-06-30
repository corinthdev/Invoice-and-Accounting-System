using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.CreditMemoDetails;
using AccountingSystems.CreditMemoHeaders;
using AccountingSystems.CreditMemos.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.CreditMemos
{
    public class CreditMemoAppService : AsyncCrudAppService<CreditMemoHeader, CreditMemoHeaderDto, int, CreditMemoRequestDto, CreateCreditMemoDto, CreditMemoHeaderDto>, ICreditMemoAppService
    {
        private readonly IRepository<CreditMemoDetail> _creditMemoDetailRepository;
        public CreditMemoAppService(
        IRepository<CreditMemoDetail> creditMemoDetailRepository,
        IRepository<CreditMemoHeader, int> repository
        ) : base(repository)
        {
            _creditMemoDetailRepository = creditMemoDetailRepository;
        }

        public async override Task<CreditMemoHeaderDto> CreateAsync(CreateCreditMemoDto input)
        {
            var header = await Repository.FirstOrDefaultAsync(x => x.CreditMemoCode == input.CreditMemoCode);
            if (header != null)
                throw new UserFriendlyException("The code is already in use.");

            return await base.CreateAsync(input);
        }

        public async Task<CreditMemoHeaderDto> GetByCodeAsync(string dto)
        {
            var result = await Repository.GetAllIncluding(x => x.Customer, x => x.Salesman)
                                         .FirstOrDefaultAsync(x => x.CreditMemoCode == dto);


            return MapToEntityDto(result);
        }

        public async Task<ListResultDto<CreditMemoListDto>> GetCreditMemo()
        {
            var creditmemos = await Repository
                .GetAll()
                .Include(x => x.Customer)
                .Include(y => y.Salesman)
                .ToListAsync();
            return new ListResultDto<CreditMemoListDto>(ObjectMapper.Map<List<CreditMemoListDto>>(creditmemos));
        }

        public override async Task<CreditMemoHeaderDto> UpdateAsync(CreditMemoHeaderDto dto)
        {

            var creditMemo = new CreditMemoHeaderDto
            {
                Id = dto.CreditMemoId,
                TenantId = dto.TenantId,
                CreditMemoCode = dto.CreditMemoCode,
                CreditMemoMode = dto.CreditMemoMode,
                SiteCode = dto.SiteCode,
                ReferenceInvoiceCode = dto.ReferenceInvoiceCode,
                CustomerId = dto.CustomerId,
                SalesmanId = dto.SalesmanId,
                TotalCase = dto.TotalCase,
                TotalBox = dto.TotalBox,
                TotalPiece = dto.TotalPiece,
                TotalGross = dto.TotalGross,
                TotalDiscount = dto.TotalDiscount,
                TotalNet = dto.TotalNet,
                Vatable = dto.Vatable,
                TwelvePercentVat = dto.TwelvePercentVat,
                CreditMemoDate = dto.CreditMemoDate,
                CreatorUsername = dto.CreatorUsername
            };
            var header = await Repository.GetAsync(dto.CreditMemoId);

            ObjectMapper.Map(creditMemo, header);

            await CurrentUnitOfWork.SaveChangesAsync();
            //await Repository.UpdateAsync(header);
            var output = await Repository.GetAllIncluding(x => x.Customer, x => x.Salesman)
                                         .FirstOrDefaultAsync(x => x.CreditMemoCode == dto.CreditMemoCode);
            return MapToEntityDto(output);
        }
        public async Task<LastCreditMemoCode> GetLastCreditMemoCode()
        {
            var output = await Repository
                .GetAll()
                .OrderBy(x => x.CreationTime)
                .LastOrDefaultAsync();

            var outputCode = ObjectMapper.Map<CreditMemoRequestDto>(output);

            if (output == null)
            {
                return null;
            }

            return new LastCreditMemoCode
            {
                CreditMemoCode = outputCode.CreditMemoCode
            };
        }

        public async Task<GetCreditMemoForEditOutput> GetCreditMemoForEdit(EntityDto input)
        {
            var result = new CreditMemoEditDto();
            var header = await Repository
                .GetAllIncluding(x => x.Customer, x => x.Salesman)
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (header != null)
            {
                ObjectMapper.Map(header, result);
                var details = await _creditMemoDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.CreditMemoHeaderId == header.Id)
                                                           .ToListAsync();

                result.CreditMemoDetails = ObjectMapper.Map<List<CreditMemoEditDetailsDto>>(details);
            }

            var creditMemoEditDto = ObjectMapper.Map<CreditMemoEditDto>(result);
            return new GetCreditMemoForEditOutput
            {
                CreditMemoEdit = creditMemoEditDto
            };
        }

        public async Task<CreditMemoEditDto> GetCreditMemoAsync(int creditMemoId)
        {
            var result = new CreditMemoEditDto();
            var invoices = await Repository
                .GetAllIncluding(x => x.Customer, x => x.Salesman)
                .FirstOrDefaultAsync(x => x.Id == creditMemoId);
            if (invoices != null)
            {
                ObjectMapper.Map(invoices, result);
                var details = await _creditMemoDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.CreditMemoHeaderId == invoices.Id)
                                                           .ToListAsync();

                result.CreditMemoDetails = ObjectMapper.Map<List<CreditMemoEditDetailsDto>>(details);
            }

            return result;
        }

        public async Task<ListResultDto<CreditMemoListDto>> GetRecentCM()
        {
            var recent = await Repository
                .GetAllIncluding(x => x.Customer, x => x.Salesman)
                .OrderByDescending(x => x.CreationTime)
                .ToListAsync();

            var lastFive = recent.Take(5);

            return new ListResultDto<CreditMemoListDto>(ObjectMapper.Map<List<CreditMemoListDto>>(lastFive));
        }

        public async Task<List<CreditMemoEditDto>> GetHeaderToExcel()
        {
            var headers = await Repository
                .GetAllIncluding(x => x.Customer, y => y.Salesman)
                .ToListAsync();

            return new List<CreditMemoEditDto>(ObjectMapper.Map<List<CreditMemoEditDto>>(headers));
        }
    }
}
