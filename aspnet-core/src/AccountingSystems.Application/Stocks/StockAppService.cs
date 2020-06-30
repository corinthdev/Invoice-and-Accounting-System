using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.Stocks.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Stocks
{
    public class StockAppService : AsyncCrudAppService<Stock, StockDto, int, StockDto, StockDto, StockDto>, IStockAppService
    {
        public StockAppService(IRepository<Stock, int> repository) 
            : base(repository)
        {
        }

        public async Task<StockDto> CheckAvailable(int productId, int totalPieces)
        {
            var available = await Repository.FirstOrDefaultAsync(x => x.ProductId == productId && x.TotalPieces >= totalPieces);
            if (available == null)
                throw new UserFriendlyException("Insufficient stock for item");

            return MapToEntityDto(available);
        }

        public async Task<StockDto> CheckIfExist(int productId)
        {
            var stock = await Repository.FirstOrDefaultAsync(x => x.ProductId == productId);

            return MapToEntityDto(stock);
        }

        public async override Task<StockDto> CreateAsync(StockDto input)
        {
            var stocks = ObjectMapper.Map<Stock>(input);
            await Repository.InsertAsync(stocks);

            return MapToEntityDto(stocks);
 
        }

        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        public async Task<ListResultDto<StockListDto>> GetStocks()
        {
            var stocks = await Repository
                .GetAll()
                .Include(x => x.Product)
                .ToListAsync();
            return new ListResultDto<StockListDto>(ObjectMapper.Map<List<StockListDto>>(stocks));
        }

        public async override Task<StockDto> UpdateAsync(StockDto toUpdate)
        {
            var stocks = await Repository.FirstOrDefaultAsync(x => x.ProductId == toUpdate.ProductId);

            ObjectMapper.Map(toUpdate, stocks);

            await Repository.UpdateAsync(stocks);

            return MapToEntityDto(stocks);
        }

        public async Task<GetTotalStocks> GetTotal()
        {
            var stocks = await Repository.GetAllListAsync();

            var allPiece = stocks.Sum(x => x.TotalPieces);

            double totalAmount = stocks.Sum(x => x.Amount);

            return new GetTotalStocks
            {
                AllPieces = allPiece,
                AllAmount = totalAmount
            };
        }

        public async Task<List<StockListDto>> ExportToExcel()
        {
            var stocks = await Repository
                .GetAll()
                .Include(x => x.Product)
                .ToListAsync();

            return new List<StockListDto>(ObjectMapper.Map<List<StockListDto>>(stocks));
        }
    }
}
