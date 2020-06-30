using AccountingSystems.Products.Dto;
using AccountingSystems.Sessions.Dto;
using AccountingSystems.Vans.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Transaction
{
    public class CreateUnloadViewModel
    {
        public IReadOnlyList<VanListDto> Vans { get; set; }

        public IReadOnlyList<ProductListDto> Products { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
