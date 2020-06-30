using AccountingSystems.Sites;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.LocationSites.Dto
{
    public class LocationSiteMapProfile : Profile
    {
        public LocationSiteMapProfile()
        {
            CreateMap<LocationSiteDto, LocationSite>()
                .ReverseMap()
                ;
        }
    }
}
