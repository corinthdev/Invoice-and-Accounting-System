﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.PurchaseOrders.Dto
{
    public class CreatePurchaseOrderDto : FullAuditedEntityDto<int>
    {
        public int PurchaseOrderId { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string PurchaseOrderCode { get; set; }
        public int SupplierId { get; set; }
        public IEnumerable<CreatePurchaseOrderDetails> PurchaseOrderDetails { get; set; }
        public int TotalCase { get; set; }
        public int TotalBox { get; set; }
        public int TotalPiece { get; set; }
        public int TotalQuantity
        {
            get
            {
                return TotalCase + TotalBox + TotalPiece;
            }
        }
        public double TotalGross { get; set; }
        public string TotalDiscount { get; set; }
        public double TotalNet { get; set; }
        public double Vatable { get; set; }
        public double TwelvePercentVat { get; set; }
        public DateTime PurhcaseDate { get; set; }
        public string CreatorUsername { get; set; }
    }
}
