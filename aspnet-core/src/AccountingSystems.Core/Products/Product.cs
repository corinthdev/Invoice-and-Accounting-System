using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AccountingSystems.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.Products
{
    [Table("AppProducts")]
    public class Product : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        public string Code { get; set; }

        public string ItemName { get; set; }

        public double Net { get; set; }

        public double PricePerPiece { get; set; }

        public double PricePerBox { get; set; }

        public double GrossPrice { get; set; }

        public double Freight { get; set; }

        public double Discount { get; set; }

        public double Vat { get; set; }

        public double PercentagePriceMargin { get; set; }

        public double PriceMargin { get; set; }

        public double PriceA { get; set; }

        public double PriceB { get; set; }

        public double PriceC { get; set; }

        public double PriceD { get; set; }

        public double PriceE { get; set; }

        public double PriceF { get; set; }

        [ForeignKey(nameof(SupplierId))]

        public Supplier Suppliers { get; set; }

        public int SupplierId { get; set; }

        public string Brand { get; set; }

        public int Cases { get; set; }

        public int Box { get; set; }

        public int Pieces { get; set; }

        public string BarcodeCase { get; set; }

        public string BarcodeItem { get; set; }


    }
}
