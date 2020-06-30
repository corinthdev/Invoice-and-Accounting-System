using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.Withdrawals.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Withdrawals
{
    public interface IWithdrawalAppService : IAsyncCrudAppService<WithdrawalHeaderDto, int, WithdrawalHeaderDto, CreateWithdrawalDto, WithdrawalHeaderDto>
    {
        Task<ListResultDto<WithdrawalListDto>> GetWithdrawal();
        Task<LastWithdrawalCode> GetLastWithdrawalCode();
        Task<GetWithdrawalForEditOutput> GetWithdrawalForEdit(EntityDto input);
        Task<WithdrawalEditDto> GetWithdrawalAsync(int withdrawalId);
        Task<List<WithdrawalEditDto>> GetHeaderToExcel();
    }
}
