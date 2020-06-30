using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Products.Dto
{
    public class ProductListDto : EntityDto
    {
        public string Code { get; set; }

        public string ItemName { get; set; }

        public double Net { get; set; }

        public double PricePerBox { get; set; }

        public double PricePerPiece { get; set; }

        public string Brand { get; set; }

        public int SupplierId { get; set; }

        public string SuppliersName { get; set; }

    }
}
