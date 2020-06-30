using AccountingSystems.RetailsEnvironments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.RetailEnvironments
{
    public class RetailEnvironmentListViewModel
    {
        public IReadOnlyList<RetailEnvironmentListDto> RetailEnvironment { get; set; }
    }
}
