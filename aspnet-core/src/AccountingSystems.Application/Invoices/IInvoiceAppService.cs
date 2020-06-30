using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.Invoices.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Invoices
{
    public interface IInvoiceAppService : IAsyncCrudAppService<InvoiceHeaderDto, int, InvoiceRequestDto, CreateInvoiceDto, InvoiceHeaderDto>
    {
        //public Task<InvoiceHeaderDto> GetByCodeAsync(InvoiceRequestDto input);
        Task<ListResultDto<InvoiceListDto>> GetInvoice();
        Task<LastInvoiceCode> GetLastInvoiceCode();
        Task<GetInvoiceForEditOutput> GetInvoiceForEdit(EntityDto input);
        Task<InvoiceEditDto> GetInvoiceAsync(int invoiceId);
        Task<ListResultDto<InvoiceListDto>> GetRecentInvoice();
        Task<List<InvoiceEditDto>> GetHeaderToExcel();
        Task<List<InvoiceEditDto>> GetAllInvoices();
    }
}
