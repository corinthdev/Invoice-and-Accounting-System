using AccountingSystems.RetailEnvironments;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.RetailsEnvironments.Dto
{
    public class RetailEnvironmentMapProfile : Profile
    {
        public RetailEnvironmentMapProfile()
        {
            CreateMap<RetailEnvironmentDto, RetailEnvironment>()
                .ForMember(x => x.CreatorUserId, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore())
                .ForMember(x => x.LastModifierUserId, opt => opt.Ignore())
                .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
                .ForMember(x => x.DeleterUserId, opt => opt.Ignore())
                .ForMember(x => x.DeletionTime, opt => opt.Ignore())
                .ReverseMap()
                ;

            CreateMap<CreateRetailEnvironmentDto, RetailEnvironment>()
                .ReverseMap()
                ;

            CreateMap<RetailEnvironment, RetailEnvironmentEditDto>();

            CreateMap<RetailEnvironment, RetailEnvironmentListDto>();
        }
    }
}
