using AccountingSystems.Customers.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Customers
{
    public class PrintCustomerViewModel
    {
        public IReadOnlyList<CustomerDto> Customers { get; set; }

        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
