using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.Stocks.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Stocks
{
    public interface IStockAppService : IAsyncCrudAppService<StockDto, int, StockDto, StockDto, StockDto>
    {
        Task<ListResultDto<StockListDto>> GetStocks();
        Task<StockDto> CheckIfExist(int productId);
        Task<StockDto> CheckAvailable(int productId, int totalPieces);
        Task<GetTotalStocks> GetTotal();
        Task<List<StockListDto>> ExportToExcel();
    }
}
