using AccountingSystems.UnloadDetails;
using AccountingSystems.UnloadHeaders;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Unloads.Dto
{
    public class UnloadMapProfile : Profile
    {
        public UnloadMapProfile()
        {
            CreateMap<UnloadHeaderDto, UnloadHeader>()
                .ForMember(x => x.CreatorUserId, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore())
                .ForMember(x => x.LastModifierUserId, opt => opt.Ignore())
                .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
                .ForMember(x => x.DeleterUserId, opt => opt.Ignore())
                .ForMember(x => x.DeletionTime, opt => opt.Ignore())
                .ForMember(x => x.Van, opt => opt.Ignore())
                .ForMember(x => x.Salesman, opt => opt.Ignore())
                .ForMember(x => x.UnloadDetails, opt => opt.Ignore())
                .ReverseMap()
                ;

            CreateMap<UnloadDetailDto, UnloadDetail>()
                .ReverseMap()
                ;
            CreateMap<CreateUnloadDto, UnloadHeader>()
                .ReverseMap()
                ;
            CreateMap<CreateUnloadDetails, UnloadDetail>()
                .ReverseMap()
                ;
            CreateMap<UnloadHeader, UnloadListDto>();
            CreateMap<UnloadHeader, UnloadRequestDto>();
            CreateMap<UnloadHeader, UnloadEditDto>();
            CreateMap<UnloadDetail, UnloadEditDto>();
            CreateMap<UnloadDetail, UnloadEditDetailsDto>();
        }
    }
}
