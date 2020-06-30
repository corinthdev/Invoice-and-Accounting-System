using AccountingSystems.Salesmans;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Salesmans.Dto
{
    public class SalesmanMapProfile : Profile
    {
        public SalesmanMapProfile()
        {
            CreateMap<CreateSalesmanDto, Salesman>();

            CreateMap<SalesmanDto, Salesman>();

            CreateMap<Salesman, SalesmanEditDto>();

            CreateMap<Salesman, SalesmanListDto>();
        }
    }
}
