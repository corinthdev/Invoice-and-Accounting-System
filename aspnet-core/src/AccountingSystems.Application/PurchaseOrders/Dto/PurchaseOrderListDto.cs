using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.PurchaseOrders.Dto
{
    public class PurchaseOrderListDto : FullAuditedEntity<int>
    {
        public string PurchaseOrderCode { get; set; }

        public string SupplierName { get; set; }

        public string SupplierAddress { get; set; }


        public DateTime PurchaseOrderDate { get; set; }

        public string CreatorUsername { get; set; }
    }
}
