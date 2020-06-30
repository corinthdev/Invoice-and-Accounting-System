using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.Customers.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Customers
{
    public class CustomerAppService : AsyncCrudAppService<Customer, CustomerDto, int, PagedCustomerResultRequestDto, CreateCustomerDto, CustomerDto>, ICustomerAppService
    {
        public CustomerAppService(IRepository<Customer, int> repository) 
            : base(repository)
        {
        }

        public override async Task<CustomerDto> CreateAsync(CreateCustomerDto input)
        {
            var hasCustomer = await Repository.FirstOrDefaultAsync(x => x.Code == input.Code);
            if(hasCustomer != null)
            {
                throw new UserFriendlyException("There is already a Customer with given customer code");
            }
            var customers = ObjectMapper.Map<Customer>(input);
            await Repository.InsertAsync(customers);
            return MapToEntityDto(customers);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var customer = await Repository.GetAsync(input.Id);
            await Repository.DeleteAsync(customer);

        }

        public async Task<List<CustomerDto>> GetAllCustomer()
        {
            var customers = await Repository
                .GetAllIncluding(x => x.Salesman)
                .ToListAsync();
            return new List<CustomerDto>(ObjectMapper.Map<List<CustomerDto>>(customers));
        }

        public override async Task<CustomerDto> GetAsync(EntityDto<int> input)
        {
            var customers = await Repository
                .GetAll()
                .Include(t => t.Salesman)
                .FirstOrDefaultAsync(x => x.Id ==input.Id);
            return MapToEntityDto(customers);
        }

        public async Task<ListResultDto<CustomerListDto>> GetCustomer()
        {
            var customers = await Repository
                .GetAll()
                .ToListAsync();
            return new ListResultDto<CustomerListDto>(ObjectMapper.Map<List<CustomerListDto>>(customers));
        }

        public async Task<GetCustomerForEditOutput> GetCustomerForEdit(EntityDto input)
        {
            var customer = await Repository
                .GetAll()
                .Include(y => y.Salesman)
                .FirstOrDefaultAsync(x => x.Id == input.Id);
            var customerEditDto = ObjectMapper.Map<CustomerEditDto>(customer);

            return new GetCustomerForEditOutput
            {
                CustomerEdit = customerEditDto
            };
        }

        public async Task<GetTotalCustomer> GetTotalCustomer()
        {
            var total = await Repository.GetAll().CountAsync();

            return new GetTotalCustomer
            {
                TotalCustomer = total
            };
        }

        public override async Task<CustomerDto> UpdateAsync(CustomerDto input)
        {
            var customer = await Repository.GetAsync(input.Id);
            ObjectMapper.Map(input, customer);

            await Repository.UpdateAsync(customer);
            return MapToEntityDto(customer);
        }
    }
}
