using AccountingSystems.Invoices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Invoice
{
    public class InvoiceListViewModel
    {
        public IReadOnlyList<InvoiceListDto> InvoiceHeaders { get; set; }
    }
}
