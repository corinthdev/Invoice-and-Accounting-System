using AccountingSystems.Salesmans.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Salesman
{
    public class PrintSalesmanViewModel
    {
        public IReadOnlyList<SalesmanListDto> Salesmen { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
