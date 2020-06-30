using Abp.AutoMapper;
using AccountingSystems.Salesmans.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Salesman
{
    [AutoMapFrom(typeof(GetSalesmanForEditOutput))]
    public class EditSalesmanModalViewModel : GetSalesmanForEditOutput
    {
    }
}
