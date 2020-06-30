using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.CreditMemos.Dto
{
    public class LastCreditMemoCode : FullAuditedEntity<int>
    {
        public string CreditMemoCode { get; set; }
    }
}
