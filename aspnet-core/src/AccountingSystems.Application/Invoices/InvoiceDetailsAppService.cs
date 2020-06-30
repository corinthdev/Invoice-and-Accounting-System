using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingSystems.InvoiceDetails;
using AccountingSystems.Invoices.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Invoices
{
    public class InvoiceDetailsAppService : AsyncCrudAppService<InvoiceDetail, InvoiceDetailDto, int, InvoiceDetailDto, InvoiceDetailDto, InvoiceDetailDto>, IInvoiceDetailsAppService
    {
        public InvoiceDetailsAppService(IRepository<InvoiceDetail, int> repository) 
            : base(repository)
        {
        }
        public async override Task<InvoiceDetailDto> CreateAsync(InvoiceDetailDto input)
        {
            return await base.CreateAsync(input);
        }
        public async override Task DeleteAsync(EntityDto<int> input)
        {
            var invoiceDetails = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(invoiceDetails);
        }

        public async Task<InvoiceEditDetailsDto> GetDetailsAsync(int invoiceHeaderId)
        {
            var invoiceDetails = await Repository.FirstOrDefaultAsync(x => x.Id == invoiceHeaderId);
            if (invoiceDetails == null)
                return null;

            return new InvoiceEditDetailsDto
            {
                TotalPieces = invoiceDetails.TotalPieces
            };
        }
        public async override Task<InvoiceDetailDto> GetAsync(EntityDto<int> input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (details == null)
                return null;

            return MapToEntityDto(details);
        }
        public async Task<List<InvoiceDetailDto>> GetInvoiceDetails()
        {
            var invoiceDetails = await Repository
                .GetAllListAsync();

            return new List<InvoiceDetailDto>(ObjectMapper.Map<List<InvoiceDetailDto>>(invoiceDetails));
        }
        public async override Task<InvoiceDetailDto> UpdateAsync(InvoiceDetailDto input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            ObjectMapper.Map(input, details);

            await Repository.UpdateAsync(details);
            return MapToEntityDto(details);
        }

        public async Task<List<InvoiceEditDetailsDto>> GetDetailsToExcel()
        {
            var details = await Repository
                .GetAllIncluding(x => x.InvoiceHeader, y => y.Product)
                .ToListAsync();

            return new List<InvoiceEditDetailsDto>(ObjectMapper.Map<List<InvoiceEditDetailsDto>>(details));
        }
    }
}
