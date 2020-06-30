using AccountingSystems.CreditMemoDetails;
using AccountingSystems.CreditMemoHeaders;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.CreditMemos.Dto
{
    class CreditMemoMapProfile : Profile
    {
        public CreditMemoMapProfile()
        {
            CreateMap<CreditMemoHeaderDto, CreditMemoHeader>()
                .ForMember(x => x.CreatorUserId, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore())
                .ForMember(x => x.LastModifierUserId, opt => opt.Ignore())
                .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
                .ForMember(x => x.DeleterUserId, opt => opt.Ignore())
                .ForMember(x => x.DeletionTime, opt => opt.Ignore())
                .ForMember(x => x.Customer, opt => opt.Ignore())
                .ForMember(x => x.Salesman, opt => opt.Ignore())
                .ForMember(x => x.CreditMemoDetails, opt => opt.Ignore())
                .ReverseMap()
                ;

            CreateMap<CreditMemoDetailDto, CreditMemoDetail>()
                .ReverseMap()
                ;
            CreateMap<CreateCreditMemoDto, CreditMemoHeader>()
                .ReverseMap()
                ;
            CreateMap<CreateCreditMemoDetails, CreditMemoDetail>()
                .ReverseMap()
                ;
            CreateMap<CreditMemoHeader, CreditMemoListDto>();
            CreateMap<CreditMemoHeader, CreditMemoRequestDto>();
            CreateMap<CreditMemoHeader, CreditMemoEditDto>();
            CreateMap<CreditMemoDetail, CreditMemoEditDto>();
            CreateMap<CreditMemoDetail, CreditMemoEditDetailsDto>();
        }
    }
}
