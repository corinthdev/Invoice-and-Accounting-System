using AccountingSystems.Invoices.Dto;
using AccountingSystems.Salesmans.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Reports
{
    public class AllInOneReportsViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
        public IReadOnlyList<InvoiceEditDto> Invoices { get; set; }
        public IReadOnlyList<SalesmanListDto> Salesmans { get; set; }
    }
}
