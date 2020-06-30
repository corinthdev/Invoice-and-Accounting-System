using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Stocks.Dto
{
    public class StockMapProfile : Profile
    {
        public StockMapProfile()
        {
            CreateMap<StockDto, Stock>()
                .ReverseMap()
                ;
            CreateMap<Stock, StockListDto>();
        }
    }
}
