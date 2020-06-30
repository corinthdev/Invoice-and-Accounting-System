using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.Products;
using AccountingSystems.Products.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Products
{
    public class ProductAppService : AsyncCrudAppService<Product, ProductDto, int, PagedProductResultRequestDto, CreateProductDto, ProductDto>, IProductAppService
    {
        public ProductAppService(IRepository<Product, int> repository, IRepository<Product> productRepository) 
            : base(repository)
        {
        }

        public override async Task<ProductDto> CreateAsync(CreateProductDto input)
        {
            var hasProducts = await Repository.FirstOrDefaultAsync(x => x.Code == input.Code);
            if (hasProducts != null)
            {
                throw new UserFriendlyException("There is already a product with given location code");
            }
            var products = ObjectMapper.Map<Product>(input);
            await Repository.InsertAsync(products);
            return MapToEntityDto(products);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var products = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(products);
        }

        public override async Task<ProductDto> GetAsync(EntityDto<int> input)
        {
            var products = await Repository.GetAsync(input.Id);

            return MapToEntityDto(products);
        }

        public async Task<ProductDto> GetProductByCode(string Code)
        {
            var product = await Repository.GetAll().FirstOrDefaultAsync(x => x.Code == Code);
            if (product == null)
                throw new UserFriendlyException("Wrong Product Code");

            return MapToEntityDto(product);
        }
        public async Task<ListResultDto<ProductListDto>> GetProduct()
        {
            var products = await Repository
                .GetAll()
                .Include(t => t.Suppliers)
                .ToListAsync();
            return new ListResultDto<ProductListDto>(ObjectMapper.Map<List<ProductListDto>>(products));
        }

        public async Task<GetProductForEditOutput> GetProductForEdit(EntityDto input)
        {
            var products = await Repository
                .GetAll()
                .Include(t => t.Suppliers)
                .FirstOrDefaultAsync(x => x.Id == input.Id);
            var productEditDto = ObjectMapper.Map<ProductEditDto>(products);

            return new GetProductForEditOutput
            {
                ProductEdit = productEditDto
            };
        }

        public override async Task<ProductDto> UpdateAsync(ProductDto input)
        {
            var products = await Repository.GetAsync(input.Id);

            ObjectMapper.Map(input, products);

            await Repository.UpdateAsync(products);

            return MapToEntityDto(products);
        }

        public async Task<GetTotalProduct> GetTotalProduct()
        {
            var total = await Repository.GetAll().CountAsync();

            return new GetTotalProduct
            {
                TotalProduct = total
            };
        }

        public async Task<List<ProductEditDto>> GetAllProduct()
        {
            var products = await Repository
                .GetAllIncluding(x => x.Suppliers)
                .ToListAsync();

            return new List<ProductEditDto>(ObjectMapper.Map<List<ProductEditDto>>(products));
        }
    }
}
