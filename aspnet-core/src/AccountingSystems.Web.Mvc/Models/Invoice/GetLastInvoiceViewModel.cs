using Abp.AutoMapper;
using AccountingSystems.Invoices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Invoice
{
    [AutoMapFrom(typeof(LastInvoiceCode))]
    public class GetLastInvoiceViewModel:LastInvoiceCode
    {
    }
}
