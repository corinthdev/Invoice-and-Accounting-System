using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.BadStocks.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.BadStocks
{
    public interface IBadStockAppService : IAsyncCrudAppService<BadStockDto, int, BadStockDto, BadStockDto, BadStockDto>
    {
        Task<ListResultDto<BadStockListDto>> GetStocks();
        Task<BadStockDto> CheckIfExist(int productId);
        Task<GetTotalBadStocks> GetTotal();
        Task<List<BadStockListDto>> ExportToExcel();
    }
}
