using AccountingSystems.Products;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Products.Dto
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<CreateProductDto, Product>();

            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductEditDto>();

            CreateMap<Product, ProductListDto>();
        }
    }
}
