using Abp.AutoMapper;
using AccountingSystems.CreditMemos.Dto;
using AccountingSystems.Invoices.Dto;
using AccountingSystems.LocationSites.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.CreditMemo
{
    public class EditCreditMemoViewModel
    {
        public GetCreditMemoForEditOutput CreditMemoEdit { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
        public IReadOnlyList<InvoiceListDto> Invoices { get; set; }
        public IReadOnlyList<LocationSiteDto> LocationSites { get; set; }
    }
}
