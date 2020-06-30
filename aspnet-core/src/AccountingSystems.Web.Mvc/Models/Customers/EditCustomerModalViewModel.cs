using AccountingSystems.Customers.Dto;
using AccountingSystems.RetailsEnvironments.Dto;
using AccountingSystems.Salesmans.Dto;
using AccountingSystems.Vans.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Customers
{
    public class EditCustomerModalViewModel
    {
        public GetCustomerForEditOutput CustomerEdit { get; set; }

        public IReadOnlyList<SalesmanListDto>  Salesmen { get; set; }

        public IReadOnlyList<RetailEnvironmentListDto> RetailEnvironmentLists { get; set; }

        public string Terms { get; set; }
    }
}
