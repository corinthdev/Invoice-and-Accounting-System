using Abp.AutoMapper;
using AccountingSystems.Withdrawals.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Withdrawals
{
    [AutoMapFrom(typeof(GetWithdrawalForEditOutput))]
    public class EditWithdrawalViewModel : GetWithdrawalForEditOutput
    {
    }
}
