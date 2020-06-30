using AccountingSystems.DebitMemoDetails;
using AccountingSystems.DebitMemoHeaders;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.DebitMemos.Dto
{
    class DebitMemoMapProfile : Profile
    {
        public DebitMemoMapProfile()
        {
            CreateMap<DebitMemoHeaderDto, DebitMemoHeader>()
                .ForMember(x => x.CreatorUserId, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore())
                .ForMember(x => x.LastModifierUserId, opt => opt.Ignore())
                .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
                .ForMember(x => x.DeleterUserId, opt => opt.Ignore())
                .ForMember(x => x.DeletionTime, opt => opt.Ignore())
                .ForMember(x => x.Supplier, opt => opt.Ignore())
                .ReverseMap()
                ;

            CreateMap<DebitMemoDetailDto, DebitMemoDetail>()
                .ReverseMap()
                ;
            CreateMap<CreateDebitMemoDto, DebitMemoHeader>()
                .ReverseMap()
                ;
            CreateMap<CreateDebitMemoDetails, DebitMemoDetail>()
                .ReverseMap()
                ;

            CreateMap<DebitMemoHeader, DebitMemoListDto>();
            CreateMap<DebitMemoHeader, DebitMemoRequestDto>();
            CreateMap<DebitMemoHeader, DebitMemoEditDto>();
            CreateMap<DebitMemoDetail, DebitMemoEditDto>();
            CreateMap<DebitMemoDetail, DebitMemoEditDetailsDto>();
        }
    }
}
