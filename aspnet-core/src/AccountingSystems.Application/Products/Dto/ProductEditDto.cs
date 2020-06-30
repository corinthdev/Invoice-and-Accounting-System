using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingSystems.Products.Dto
{
    public class ProductEditDto : EntityDto<int>, IMustHaveTenant
    {
        public int TenantId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string ItemName { get; set; }

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

        public int SupplierId { get; set; }

        public string SuppliersCode { get; set; }

        public string SuppliersName { get; set; }

        public string Brand { get; set; }

        public int Cases { get; set; }

        public int Box { get; set; }

        public int Pieces { get; set; }

        public string BarcodeCase { get; set; }

        public string BarcodeItem { get; set; }

        public double Net
        {
            get
            {
                return (GrossPrice - GrossPrice * (Discount / 100)) * (100 + Vat) / 100 + Freight;
            }
        }

        public double PricePerPiece
        {
            get
            {
                return Net * ((100 + PercentagePriceMargin) / 100) / Cases + PriceMargin;
            }
        }

        public double PricePerBox
        {
            get
            {
                return Net * ((100 + PercentagePriceMargin) / 100) / Box + PriceMargin;
            }
        }
    }
}
