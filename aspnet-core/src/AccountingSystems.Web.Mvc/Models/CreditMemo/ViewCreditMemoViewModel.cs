using Abp.AutoMapper;
using AccountingSystems.CreditMemos.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.CreditMemo
{
    public class ViewCreditMemoViewModel
    {
        public GetCreditMemoForEditOutput CreditMemoEdit { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
