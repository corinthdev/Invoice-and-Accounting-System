using Abp.Application.Services;
using AccountingSystems.CreditMemos.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.CreditMemos
{
    public interface ICreditMemoDetailsAppService : IAsyncCrudAppService<CreditMemoDetailDto, int, CreditMemoDetailDto, CreditMemoDetailDto, CreditMemoDetailDto>
    {
        Task<CreditMemoEditDetailsDto> GetDetailsAsync(int creditMemoHeaderId);
        Task<List<CreditMemoEditDetailsDto>> GetDetailsToExcel();
    }
}
