using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.VanStocks.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.VanStocks
{
    public interface IVanStockAppService : IAsyncCrudAppService<VanStockDto, int, VanStockDto, VanStockDto, VanStockDto>
    {
        Task<ListResultDto<VanStockListDto>> GetVanStocks(int vanId);
        Task<VanStockDto> CheckIfExist(int productId, int vanId);
        Task<VanStockDto> CheckAvailable(int productId, int totalPieces, int vanId);
        Task<GetTotal> GetTotal(int vanId);
        Task<List<VanStockListDto>> GetVanStocksToExcel();

        //Task<ListResultDto<GetTotalVanStock>> GetTotalVanstock(int vanId);
    }
}
