using Abp.AutoMapper;
using AccountingSystems.PurchaseOrders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.PurchaseOrder
{
    [AutoMapFrom(typeof(GetPurchaseOrderForEditOutput))]
    public class ViewPurchaseOrderViewModel : GetPurchaseOrderForEditOutput
    {
    }
}
