using Abp.AutoMapper;
using AccountingSystems.DebitMemos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.DebitMemo
{
    [AutoMapFrom(typeof(LastDebitMemoCode))]
    public class GetLastDebitMemoViewModel : LastDebitMemoCode
    {
    }
}
