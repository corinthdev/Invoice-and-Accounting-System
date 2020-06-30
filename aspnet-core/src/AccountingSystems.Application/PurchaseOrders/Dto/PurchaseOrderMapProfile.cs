using AccountingSystems.PurchaseOrderDetails;
using AccountingSystems.PurchaseOrderHeaders;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.PurchaseOrders.Dto
{
    class PurchaseOrderMapProfile : Profile
    {
        public PurchaseOrderMapProfile()
        {
            CreateMap<PurchaseOrderHeaderDto, PurchaseOrderHeader>()
                .ForMember(x => x.CreatorUserId, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore())
                .ForMember(x => x.LastModifierUserId, opt => opt.Ignore())
                .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
                .ForMember(x => x.DeleterUserId, opt => opt.Ignore())
                .ForMember(x => x.DeletionTime, opt => opt.Ignore())
                .ForMember(x => x.Supplier, opt => opt.Ignore())
                .ForMember(x => x.PurchaseOrderDetails, opt => opt.Ignore())
                .ReverseMap()
                ;

            CreateMap<PurchaseOrderDetailDto, PurchaseOrderDetail>()
                .ReverseMap()
                ;
            CreateMap<CreatePurchaseOrderDto, PurchaseOrderHeader>()
                .ReverseMap()
                ;
            CreateMap<CreatePurchaseOrderDetails, PurchaseOrderDetail>()
                .ReverseMap()
                ;
            CreateMap<PurchaseOrderHeader, PurchaseOrderListDto>();
            CreateMap<PurchaseOrderHeader, PurchaseOrderRequestDto>();
            CreateMap<PurchaseOrderHeader, PurchaseOrderEditDto>();
            CreateMap<PurchaseOrderDetail, PurchaseOrderEditDto>();
            CreateMap<PurchaseOrderDetail, PurchaseOrderEditDetailsDto>();

        }
    }
}
