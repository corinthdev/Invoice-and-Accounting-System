using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.Salesmans;
using AccountingSystems.Salesmans.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Salesmans
{
    public interface ISalesmanAppService : IAsyncCrudAppService<SalesmanDto, int, PagedSalesmanResultRequestDto, CreateSalesmanDto, SalesmanDto>
    {
        Task<ListResultDto<SalesmanListDto>> GetSalesman();
        Task<GetSalesmanForEditOutput> GetSalesmanForEdit(EntityDto input);
        Task<GetSalesmanNameOutput> GetSalesmanName(string salesmanCode);

        Task<GetTotalSalesman> GetTotalSalesman();
        Task<List<SalesmanListDto>> GetSalesmanToExcel();
    }
}
