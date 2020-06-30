using AccountingSystems.BookingDetails;
using AccountingSystems.BookingHeaders;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Bookings.Dto
{
    public class BookingMapProfile : Profile
    {
        public BookingMapProfile()
        {
            CreateMap<BookingHeaderDto, BookingHeader>()
                .ForMember(x => x.CreatorUserId, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore())
                .ForMember(x => x.LastModifierUserId, opt => opt.Ignore())
                .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
                .ForMember(x => x.DeleterUserId, opt => opt.Ignore())
                .ForMember(x => x.DeletionTime, opt => opt.Ignore())
                .ForMember(x => x.Customer, opt => opt.Ignore())
                .ForMember(x => x.Salesman, opt => opt.Ignore())
                .ForMember(x => x.BookingDetails, opt => opt.Ignore())
                .ReverseMap()
                ;

            CreateMap<BookingDetailDto, BookingDetail>()
                .ReverseMap()
                ;

            CreateMap<CreateBookingDto, BookingHeader>()
                .ReverseMap()
                ;
            CreateMap<CreateBookingDetails, BookingDetail>()
                .ReverseMap()
                ;
            CreateMap<BookingHeader, BookingListDto>();
            CreateMap<BookingHeader, BookingRequestDto>();
            CreateMap<BookingHeader, BookingEditDto>();
            CreateMap<BookingDetail, BookingEditDto>();
            CreateMap<BookingDetail, BookingEditDetailsDto>();
        }
    }
}
