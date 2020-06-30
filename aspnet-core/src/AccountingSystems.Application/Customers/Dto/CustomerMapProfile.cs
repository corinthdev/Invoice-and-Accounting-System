using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Customers.Dto
{
    public class CustomerMapProfile : Profile
    {
        public CustomerMapProfile()
        {
            CreateMap<CreateCustomerDto, Customer>();

            CreateMap<CustomerDto, Customer>();

            CreateMap<Customer, CustomerListDto>();

            CreateMap<Customer, CustomerEditDto>();
        }
    }
}
