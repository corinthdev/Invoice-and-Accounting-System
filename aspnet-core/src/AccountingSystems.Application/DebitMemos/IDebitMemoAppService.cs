using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.DebitMemos.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.DebitMemos
{
    public interface IDebitMemoAppService : IAsyncCrudAppService<DebitMemoHeaderDto, int, DebitMemoRequestDto, CreateDebitMemoDto, DebitMemoHeaderDto>
    {
        Task<ListResultDto<DebitMemoListDto>> GetDebitMemo();

        Task<LastDebitMemoCode> GetLastDebitMemoCode();

        Task<GetDebitMemoForEditOutput> GetDebitMemoForEdit(EntityDto input);

        Task<DebitMemoEditDto> GetDebitMemoAsync(int debitMemoId);

        Task<ListResultDto<DebitMemoListDto>> GetRecentDM();
        Task<List<DebitMemoEditDto>> GetHeaderToExcel();
    }
}
