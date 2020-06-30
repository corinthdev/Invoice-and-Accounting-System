using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.CreditMemos.Dto;
using AccountingSystems.Invoices.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.CreditMemos
{
    public interface ICreditMemoAppService : IAsyncCrudAppService<CreditMemoHeaderDto, int, CreditMemoRequestDto, CreateCreditMemoDto, CreditMemoHeaderDto>
    {
        Task<ListResultDto<CreditMemoListDto>> GetCreditMemo();
        Task<LastCreditMemoCode> GetLastCreditMemoCode();
        Task<GetCreditMemoForEditOutput> GetCreditMemoForEdit(EntityDto input);
        Task<CreditMemoEditDto> GetCreditMemoAsync(int creditMemoId);
        Task<ListResultDto<CreditMemoListDto>> GetRecentCM();
        Task<List<CreditMemoEditDto>> GetHeaderToExcel();
    }
}
