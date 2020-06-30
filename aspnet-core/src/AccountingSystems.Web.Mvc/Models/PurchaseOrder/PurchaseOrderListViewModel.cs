using AccountingSystems.PurchaseOrders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.PurchaseOrder
{
    public class PurchaseOrderListViewModel
    {
        public IReadOnlyList<PurchaseOrderListDto> PurchaseOrders { get; set; }
    }
}
