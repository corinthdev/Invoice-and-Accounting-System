using Abp.AutoMapper;
using AccountingSystems.LocationSites.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.LocationSites
{
    [AutoMapFrom(typeof(GetLocationSiteForEditOutput))]
    public class EditLocationSiteModalViewModel : GetLocationSiteForEditOutput
    {
    }
}
