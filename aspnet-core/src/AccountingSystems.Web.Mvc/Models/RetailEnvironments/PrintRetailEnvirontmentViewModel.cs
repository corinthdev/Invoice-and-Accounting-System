using AccountingSystems.RetailsEnvironments.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.RetailEnvironments
{
    public class PrintRetailEnvirontmentViewModel
    {
        public IReadOnlyList<RetailEnvironmentListDto> RetailEnvirontments { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
