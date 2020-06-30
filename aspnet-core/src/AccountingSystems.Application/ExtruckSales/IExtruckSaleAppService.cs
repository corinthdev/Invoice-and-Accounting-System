using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.ExtruckSales.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.ExtruckSales
{
    public interface IExtruckSaleAppService : IAsyncCrudAppService<ExtruckHeaderDto, int, ExtruckSaleRequestDto, ExtruckHeaderDto, ExtruckHeaderDto>
    {
        Task<ListResultDto<ExtruckSaleListDto>> GetExtruckSale();
        Task<GetExtruckSaleForEditOutput> GetExtruckSaleForEdit(EntityDto input);
    }
}
