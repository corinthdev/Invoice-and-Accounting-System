using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Withdrawals.Dto
{
    public class WithdrawalListDto : FullAuditedEntity<int>
    {
        public string WithdrawalCode { get; set; }

        public string VanName { get; set; }

        public string VanDistrict { get; set; }

        public string SalesmanName { get; set; }

        public DateTime WithdrawalDate { get; set; }

        public string CreatorUsername { get; set; }


    }
}
