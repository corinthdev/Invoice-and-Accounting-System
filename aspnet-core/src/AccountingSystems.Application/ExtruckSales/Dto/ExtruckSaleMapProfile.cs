using AccountingSystems.ExtruckSaleDetails;
using AccountingSystems.ExtruckSaleHeaders;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.ExtruckSales.Dto
{
    public class ExtruckSaleMapProfile : Profile
    {
        public ExtruckSaleMapProfile()
        {
            CreateMap<ExtruckHeaderDto, ExtruckSaleHeader>()
                .ForMember(x => x.CreatorUserId, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore())
                .ForMember(x => x.LastModifierUserId, opt => opt.Ignore())
                .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
                .ForMember(x => x.DeleterUserId, opt => opt.Ignore())
                .ForMember(x => x.DeletionTime, opt => opt.Ignore())
                .ForMember(x => x.Customer, opt => opt.Ignore())
                .ForMember(x => x.Salesman, opt => opt.Ignore())
                .ReverseMap()
                ;

            CreateMap<ExtruckSaleDetailDto, ExtruckSaleDetail>()
                .ReverseMap()
                ;
            CreateMap<ExtruckSaleHeader, ExtruckSaleListDto>();
            CreateMap<ExtruckSaleHeader, ExtruckSaleRequestDto>();
            CreateMap<ExtruckSaleHeader, ExtruckSaleEditDto>();
            CreateMap<ExtruckSaleDetail, ExtruckSaleEditDto>();
            CreateMap<ExtruckSaleDetail, ExtruckSaleEditDetailsDto>();
        }
    }
}
