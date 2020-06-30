using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.PurchaseOrders.Dto
{
    public class PurchaseOrderRequestDto : PagedResultRequestDto
    {
        public string PurchaseOrderCode { get; set; }
    }
}
