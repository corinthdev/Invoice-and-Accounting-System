using AccountingSystems.Withdrawals.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Withdrawals
{
    public class WithdrawalListViewModel
    {
        public IReadOnlyList<WithdrawalListDto> Withdrawals { get; set; }
    }
}
