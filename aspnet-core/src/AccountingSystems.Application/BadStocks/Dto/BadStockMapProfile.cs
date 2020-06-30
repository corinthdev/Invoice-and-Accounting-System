using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.BadStocks.Dto
{
    public class BadStockMapProfile : Profile
    {
        public BadStockMapProfile()
        {
            CreateMap<BadStockDto, BadStock>()
            .ReverseMap()
            ;
            CreateMap<BadStock, BadStockListDto>();
        }
    }
}
