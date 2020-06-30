using AccountingSystems.Salesmans.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Salesman
{
    public class SalesmanListViewModel
    {
        public IReadOnlyList<SalesmanListDto> Salesmen { get; set; }
    }
}
