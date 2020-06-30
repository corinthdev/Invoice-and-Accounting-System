using Abp.AutoMapper;
using AccountingSystems.CreditMemos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.CreditMemo
{
    [AutoMapFrom(typeof(LastCreditMemoCode))]
    public class GetLastCreditMemoViewModel : LastCreditMemoCode
    {
    }
}
