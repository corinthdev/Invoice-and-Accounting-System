using AccountingSystems.LocationSites.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.LocationSites
{
    public class LocationSiteListViewModel
    {
        public IReadOnlyList<LocationSiteDto> LocationSites { get; set; }
    }
}
