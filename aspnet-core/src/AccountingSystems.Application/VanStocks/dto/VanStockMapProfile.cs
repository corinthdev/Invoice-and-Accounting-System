using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.VanStocks.dto
{
    public class VanStockMapProfile : Profile
    {
        public VanStockMapProfile()
        {
            CreateMap<VanStockDto, VanStock>()
                .ReverseMap()
                ;
            CreateMap<VanStock, VanStockListDto>();
        }
    }
}
