using Abp.Application.Services;
using AccountingSystems.Withdrawals.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Withdrawals
{
    public interface IWithdrawalDetailsAppService : IAsyncCrudAppService<WithdrawalDetailDto, int, WithdrawalDetailDto, WithdrawalDetailDto, WithdrawalDetailDto>
    {
        Task<WithdrawalEditDetailsDto> GetDetailsAsync(int withdrawalHeaderId);
        Task<List<WithdrawalEditDetailsDto>> GetDetailsToExcel();
    }
}
