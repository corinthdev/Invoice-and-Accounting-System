using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.DebitMemos.Dto
{
    public class DebitMemoListDto : FullAuditedEntity<int>
    {
        public string DebitMemoCode { get; set; }

        public string SupplierName { get; set; }

        public string SupplierAddress { get; set; }


        public DateTime DebitMemoDate { get; set; }

        public string CreatorUsername { get; set; }
    }
}
