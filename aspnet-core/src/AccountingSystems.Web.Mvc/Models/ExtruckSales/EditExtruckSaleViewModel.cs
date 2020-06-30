using Abp.AutoMapper;
using AccountingSystems.ExtruckSales.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.ExtruckSales
{
    [AutoMapFrom(typeof(GetExtruckSaleForEditOutput))]
    public class EditExtruckSaleViewModel : GetExtruckSaleForEditOutput
    {
    }
}
