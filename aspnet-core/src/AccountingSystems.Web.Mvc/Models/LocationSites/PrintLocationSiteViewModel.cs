using AccountingSystems.LocationSites.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.LocationSites
{
    public class PrintLocationSiteViewModel
    {
        public IReadOnlyList<LocationSiteDto> LocationSites { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
