using Abp.Application.Services;
using AccountingSystems.DebitMemos.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.DebitMemos
{
    public interface IDebitMemoDetailsAppService : IAsyncCrudAppService<DebitMemoDetailDto, int, DebitMemoDetailDto, DebitMemoDetailDto, DebitMemoDetailDto>
    {
        Task<DebitMemoEditDetailsDto> GetDetailsAsync(int creditMemoHeaderId);
        Task<List<DebitMemoEditDetailsDto>> GetDetailsToExcel();
    }
}
