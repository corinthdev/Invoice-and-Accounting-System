using AccountingSystems.WithdrawalDetails;
using AccountingSystems.WithdrawalHeaders;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Withdrawals.Dto
{
    public class WithdrawalMapProfile : Profile
    {
        public WithdrawalMapProfile()
        {
            CreateMap<WithdrawalHeaderDto, WithdrawalHeader>()
                .ForMember(x => x.CreatorUserId, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore())
                .ForMember(x => x.LastModifierUserId, opt => opt.Ignore())
                .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
                .ForMember(x => x.DeleterUserId, opt => opt.Ignore())
                .ForMember(x => x.DeletionTime, opt => opt.Ignore())
                .ForMember(x => x.Van, opt => opt.Ignore())
                .ForMember(x => x.Salesman, opt => opt.Ignore())
                .ForMember(x => x.WithdrawalDetails, opt => opt.Ignore())
                .ReverseMap()
                ;

            CreateMap<WithdrawalDetailDto, WithdrawalDetail>()
                .ReverseMap()
                ;
            CreateMap<CreateWithdrawalDto, WithdrawalHeader>()
                .ReverseMap()
                ;
            CreateMap<CreateWithdrawalDetails, WithdrawalDetail>()
                .ReverseMap()
                ;
            CreateMap<WithdrawalHeader, WithdrawalListDto>();
            CreateMap<WithdrawalHeader, WithdrawalRequestDto>();
            CreateMap<WithdrawalHeader, WithdrawalEditDto>();
            CreateMap<WithdrawalDetail, WithdrawalEditDto>();
            CreateMap<WithdrawalDetail, WithdrawalEditDetailsDto>();
        }
    }
}
