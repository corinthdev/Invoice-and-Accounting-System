using AccountingSystems.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Transaction
{
    public class CreateTransferStockViewModel
    {
        public IReadOnlyList<ProductListDto> Products { get; set; }
    }
}
