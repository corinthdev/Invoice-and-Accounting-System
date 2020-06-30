using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.Invoices.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Invoices
{
    public interface IInvoiceDetailsAppService : IAsyncCrudAppService<InvoiceDetailDto, int, InvoiceDetailDto, InvoiceDetailDto, InvoiceDetailDto>
    {
        Task<List<InvoiceDetailDto>> GetInvoiceDetails();
        Task<InvoiceEditDetailsDto> GetDetailsAsync(int invoiceHeaderId);
        Task<List<InvoiceEditDetailsDto>> GetDetailsToExcel();
    }
}
