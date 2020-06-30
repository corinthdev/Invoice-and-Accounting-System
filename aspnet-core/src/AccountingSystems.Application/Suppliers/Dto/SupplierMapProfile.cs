using AccountingSystems.Suppliers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Suppliers.Dto
{
    public class SupplierMapProfile : Profile
    {
        public SupplierMapProfile()
        {
            CreateMap<CreateSupplierDto, Supplier>();

            CreateMap<SupplierDto, Supplier>();

            CreateMap<Supplier, SupplierEditDto>();

            CreateMap<Supplier, SupplierListDto>();
        }
    }
}
