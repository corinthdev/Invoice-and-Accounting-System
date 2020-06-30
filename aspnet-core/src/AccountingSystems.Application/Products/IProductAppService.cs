using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.Products.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Products
{
    public interface IProductAppService : IAsyncCrudAppService<ProductDto, int, PagedProductResultRequestDto, CreateProductDto, ProductDto>
    {
        Task<ListResultDto<ProductListDto>> GetProduct();
        Task<GetProductForEditOutput> GetProductForEdit(EntityDto input);
        Task<GetTotalProduct> GetTotalProduct();
        Task<List<ProductEditDto>> GetAllProduct();
    }
}
