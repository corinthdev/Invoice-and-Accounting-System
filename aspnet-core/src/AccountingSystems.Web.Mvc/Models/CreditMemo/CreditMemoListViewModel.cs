using AccountingSystems.CreditMemos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.CreditMemo
{
    public class CreditMemoListViewModel
    {
        public IReadOnlyList<CreditMemoListDto> CreditMemos { get; set; }
    }
}
