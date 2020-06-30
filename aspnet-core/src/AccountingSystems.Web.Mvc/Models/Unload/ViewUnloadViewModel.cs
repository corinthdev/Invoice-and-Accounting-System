using Abp.AutoMapper;
using AccountingSystems.Unloads.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Unload
{
    [AutoMapFrom(typeof(GetUnloadForEditOutput))]
    public class ViewUnloadViewModel : GetUnloadForEditOutput
    {
    }
}
