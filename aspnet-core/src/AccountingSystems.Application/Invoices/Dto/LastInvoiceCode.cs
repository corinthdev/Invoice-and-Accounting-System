using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Invoices.Dto
{
    public class LastInvoiceCode : FullAuditedEntity<int>
    {
        public string InvoiceCode { get; set; }
    }
}
