using AccountingSystems.Products.Dto;
using AccountingSystems.Suppliers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Stocks
{
    public class CreateStocksViewModel
    {
        public IReadOnlyList<ProductListDto> Products { get; set; }
    }
}
