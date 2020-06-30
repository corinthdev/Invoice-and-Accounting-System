using Abp.AutoMapper;
using AccountingSystems.Customers;
using AccountingSystems.InvoiceHeaders;
using AccountingSystems.Invoices.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Invoice
{
    public class EditInvoiceViewModel
    {
        public GetInvoiceForEditOutput EditInvoice { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
        //public IReadOnlyList<Customer> Customers { get; set; }
    }
}
