using Abp.AutoMapper;
using AccountingSystems.Invoices.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Invoice
{
    public class ViewInvoiceViewModel
    {
        public GetInvoiceForEditOutput EditInvoice { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
