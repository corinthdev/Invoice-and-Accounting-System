using AccountingSystems.Branches;
using AccountingSystems.Customers.Dto;
using AccountingSystems.RetailsEnvironments.Dto;
using AccountingSystems.Salesmans.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Customers
{
    public class CustomerListViewModel
    {
        public IReadOnlyList<CustomerListDto> Customers { get; set; }

        public IReadOnlyList<SalesmanListDto> Salesmen { get; set; }

        public IReadOnlyList<RetailEnvironmentListDto> RetailEnvironmentLists { get; set; }

        public string Terms { get; set; }

    }
}
