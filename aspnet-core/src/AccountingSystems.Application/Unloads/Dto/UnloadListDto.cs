using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Unloads.Dto
{
    public class UnloadListDto : FullAuditedEntity<int>
    {
        public string UnloadCode { get; set; }

        public string VanName { get; set; }

        public string VanDistrict { get; set; }

        public string SalesmanName { get; set; }

        public DateTime UnloadDate { get; set; }

        public string CreatorUsername { get; set; }
    }
}
