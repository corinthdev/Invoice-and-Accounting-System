using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Customers
{
    public interface ICustomerAppService : IAsyncCrudAppService<CustomerDto, int, PagedCustomerResultRequestDto, CreateCustomerDto, CustomerDto>
    {
        Task<ListResultDto<CustomerListDto>> GetCustomer();
        Task<GetCustomerForEditOutput> GetCustomerForEdit(EntityDto input);
        Task<GetTotalCustomer> GetTotalCustomer();
        Task<List<CustomerDto>> GetAllCustomer();
    }
}
