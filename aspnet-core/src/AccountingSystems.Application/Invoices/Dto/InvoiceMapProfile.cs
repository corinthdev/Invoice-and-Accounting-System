using AccountingSystems.InvoiceDetails;
using AccountingSystems.InvoiceHeaders;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Invoices.Dto
{
    public class InvoiceMapProfile : Profile
    {
        public InvoiceMapProfile()
        {
            CreateMap<InvoiceHeaderDto, InvoiceHeader>()
                .ForMember(x => x.CreatorUserId, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore())
                .ForMember(x => x.LastModifierUserId, opt => opt.Ignore())
                .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
                .ForMember(x => x.DeleterUserId, opt => opt.Ignore())
                .ForMember(x => x.DeletionTime, opt => opt.Ignore())
                .ForMember(x => x.Customer, opt => opt.Ignore())
                .ForMember(x => x.Salesman, opt => opt.Ignore())
                .ForMember(x => x.InvoiceDetails, opt => opt.Ignore())
                .ReverseMap()
                ;

            CreateMap<InvoiceDetailDto, InvoiceDetail>()
                .ReverseMap()
                ;
            CreateMap<CreateInvoiceDto, InvoiceHeader>()
                .ReverseMap()
                ;
            CreateMap<CreateInvoiceDetails, InvoiceDetail>()
                .ReverseMap()
                ;
            CreateMap<InvoiceHeader, InvoiceListDto>();
            CreateMap<InvoiceHeader, InvoiceRequestDto>();
            CreateMap<InvoiceHeader, InvoiceEditDto>();
            CreateMap<InvoiceDetail, InvoiceEditDto>();
            CreateMap<InvoiceDetail, InvoiceEditDetailsDto>();
        }
    }
}
