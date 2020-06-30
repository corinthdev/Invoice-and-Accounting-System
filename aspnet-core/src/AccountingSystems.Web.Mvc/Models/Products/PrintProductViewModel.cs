using AccountingSystems.Products.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Products
{
    public class PrintProductViewModel
    {
        public IReadOnlyList<ProductEditDto> Products { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
