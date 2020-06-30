using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.InvoiceDetails;
using AccountingSystems.InvoiceHeaders;
using AccountingSystems.Invoices.Dto;
using AccountingSystems.Managers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Invoices
{
    public class InvoiceAppService : AsyncCrudAppService<InvoiceHeader, InvoiceHeaderDto, int, InvoiceRequestDto, CreateInvoiceDto, InvoiceHeaderDto>, IInvoiceAppService
    {
        private readonly IRepository<InvoiceDetail> _invoiceDetailRepository;
        public InvoiceAppService(
        IRepository<InvoiceDetail> invoiceDetailRepository,
        IRepository<InvoiceHeader, int> repository) : base(repository)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
        }

        public override async Task<InvoiceHeaderDto> CreateAsync(CreateInvoiceDto input)
        {
            var header = await Repository.FirstOrDefaultAsync(x => x.InvoiceCode == input.InvoiceCode);

            if (header != null)
                throw new UserFriendlyException("The code is already in use.");

            return await base.CreateAsync(input);
        }

        public async Task<InvoiceHeaderDto> GetByCodeAsync(string dto)
        {
            var result = await Repository.GetAllIncluding(x => x.Customer, x => x.Salesman)
                                         .FirstOrDefaultAsync(x => x.InvoiceCode == dto);


            return MapToEntityDto(result);
        }

        public async Task<ListResultDto<InvoiceListDto>> GetInvoice()
        {
            var invoices = await Repository
                .GetAll()
                .Include(x => x.Customer)
                .Include(y => y.Salesman)
                .ToListAsync();
            return new ListResultDto<InvoiceListDto>(ObjectMapper.Map<List<InvoiceListDto>>(invoices));
        }

        public override async Task<InvoiceHeaderDto> UpdateAsync(InvoiceHeaderDto dto)
        {
            var invoices = new InvoiceHeaderDto
            {
                Id = dto.InvoiceId,
                TenantId = dto.TenantId,
                InvoiceCode = dto.InvoiceCode,
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
                InvoiceDate = dto.InvoiceDate,
                CreatorUsername = dto.CreatorUsername,
                EditorUsername = dto.EditorUsername
            };
            var header = await Repository.GetAsync(dto.InvoiceId);
            ObjectMapper.Map(invoices, header);

            await CurrentUnitOfWork.SaveChangesAsync();
            //await Repository.UpdateAsync(header);
            var output = await Repository.GetAllIncluding(x => x.Customer, x => x.Salesman)
                                         .FirstOrDefaultAsync(x => x.InvoiceCode == dto.InvoiceCode);
            return MapToEntityDto(output);
        }
        public async Task<LastInvoiceCode> GetLastInvoiceCode()
        {
            var output = await Repository
                .GetAll()
                .OrderBy(x => x.CreationTime)
                .LastOrDefaultAsync();

            var outputCode = ObjectMapper.Map<InvoiceRequestDto>(output);

            if (output == null)
            {
                return null;
            }

            return new LastInvoiceCode
            {
                InvoiceCode = outputCode.InvoiceCode
            };
        }

        public async Task<GetInvoiceForEditOutput> GetInvoiceForEdit(EntityDto input)
        {
            var result = new InvoiceEditDto();
            var header = await Repository
                .GetAllIncluding(x => x.Customer, x => x.Salesman)
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (header != null)
            {
                ObjectMapper.Map(header, result);
                var details = await _invoiceDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.InvoiceHeaderId == header.Id)
                                                           .ToListAsync();

                result.InvoiceDetails = ObjectMapper.Map<List<InvoiceEditDetailsDto>>(details);
            }

            var invoiceEditDto = ObjectMapper.Map<InvoiceEditDto>(result);
            return new GetInvoiceForEditOutput
            {
                EditInvoice = invoiceEditDto
            };
        }

        public async Task<InvoiceEditDto> GetInvoiceAsync(int invoiceId)
        {
            var result = new InvoiceEditDto();
            var invoices = await Repository
                .GetAllIncluding(x => x.Customer, x => x.Salesman)
                .FirstOrDefaultAsync(x => x.Id == invoiceId);
            if (invoices != null)
            {
                ObjectMapper.Map(invoices, result);
                var details = await _invoiceDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.InvoiceHeaderId == invoices.Id)
                                                           .ToListAsync();

                result.InvoiceDetails = ObjectMapper.Map<List<InvoiceEditDetailsDto>>(details);
            }

            return result;
        }

        public async Task<ListResultDto<InvoiceListDto>> GetRecentInvoice()
        {
            var recent = await Repository
                .GetAllIncluding(x => x.Customer, x => x.Salesman)
                .OrderByDescending(x => x.CreationTime)
                .ToListAsync();

            var lastFive = recent.Take(5);

            return new ListResultDto<InvoiceListDto>(ObjectMapper.Map<List<InvoiceListDto>>(lastFive));
        }

        public async Task<List<InvoiceEditDto>> GetHeaderToExcel()
        {
            var headers = await Repository
                .GetAllIncluding(x => x.Customer, y => y.Salesman)
                .ToListAsync();

            return new List<InvoiceEditDto>(ObjectMapper.Map<List<InvoiceEditDto>>(headers));
        }

        public async Task<List<InvoiceEditDto>> GetAllInvoices()
        {
            var invoices = await Repository
                .GetAllIncluding(x => x.Customer, y => y.Salesman)
                .ToListAsync();

            return new List<InvoiceEditDto>(ObjectMapper.Map<List<InvoiceEditDto>>(invoices));
        }
    }
}