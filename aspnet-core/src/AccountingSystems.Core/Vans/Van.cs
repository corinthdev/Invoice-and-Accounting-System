using Abp.Domain.Entities.Auditing;
using AccountingSystems.Salesmans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.Vans
{
    [Table("AppVans")]
    public class Van : FullAuditedEntity<int>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string PlateNumber { get; set; }

        public string District { get; set; }
        
        [ForeignKey(nameof(SalesmanId))]
        public Salesman Salesman { get; set; }

        public int SalesmanId { get; set; }
    }
}
