using AccountingSystems.Vans;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Vans.Dto
{
    public class VanMapProfile : Profile
    {
        public VanMapProfile()
        {
            CreateMap<CreateVanDto, Van>();

            CreateMap<VanDto, Van>();

            CreateMap<Van, VanEditDto>();

            CreateMap<Van, VanListDto>();
        }
    }
}
