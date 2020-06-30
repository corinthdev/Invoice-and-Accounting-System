using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.VanStocks.dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.VanStocks
{
    public class VanStockAppService : AsyncCrudAppService<VanStock, VanStockDto, int, VanStockDto, VanStockDto, VanStockDto>, IVanStockAppService
    {
        public VanStockAppService(IRepository<VanStock, int> repository) 
            : base(repository)
        {
        }

        public async Task<VanStockDto> CheckAvailable(int productId, int totalPieces, int vanId)
        {
            var available = await Repository.FirstOrDefaultAsync(x => x.ProductId == productId && x.VanId == vanId && x.TotalPieces >= totalPieces);
            if (available == null)
                throw new UserFriendlyException("Insufficient stock for item");

            return MapToEntityDto(available);
        }

        public async Task<VanStockDto> CheckIfExist(int productId, int vanId)
        {
            var stock = await Repository.FirstOrDefaultAsync(x => x.ProductId == productId && x.VanId == vanId);
            if (stock == null)
                return null;

            return MapToEntityDto(stock);
        }
        public async Task<VanStockDto> CheckIfExisting(int productId, int vanId)
        {
            var stock = await Repository.FirstOrDefaultAsync(x => x.ProductId == productId && x.VanId == vanId);
            if (stock == null)
                throw new UserFriendlyException("Item does not exist in Van Stocks");

            return MapToEntityDto(stock);
        }
        public async override Task<VanStockDto> CreateAsync(VanStockDto input)
        {
            var stocks = ObjectMapper.Map<VanStock>(input);
            await Repository.InsertAsync(stocks);

            return MapToEntityDto(stocks);

        }
        public async Task<GetTotal> GetTotal(int vanId)
        {
            var stocks = await Repository
                .GetAll()
                .Where(x => x.VanId == vanId)
                .ToListAsync();
            var vanName = await Repository.FirstOrDefaultAsync(x => x.VanId == vanId);
            if (vanName == null)
            {
                return new GetTotal
                {
                    VanName = 0,
                    AllPieces = 0,
                    AllAmount = 0
                };
            }
            var allPiece = stocks.Sum(x => x.TotalPieces);

            double totalAmount = stocks.Sum(x => x.Amount);

            return new GetTotal
            {
                VanName = vanName.VanId,
                AllPieces = allPiece,
                AllAmount = totalAmount
            };
        }

        public async Task<ListResultDto<VanStockListDto>> GetVanStocks(int vanId)
        {
            var stocks = await Repository
                .GetAll()
                .Include(x => x.Product)
                .Include(x => x.Van)
                .Where(x => x.VanId == vanId)
                .ToListAsync();

            return new ListResultDto<VanStockListDto>(ObjectMapper.Map<List<VanStockListDto>>(stocks));
        }

        public async Task<List<VanStockListDto>> GetVanStocksToExcel()
        {
            var vanStocks = await Repository
                .GetAllIncluding(x => x.Product, y => y.Van)
                .ToListAsync();
            return new List<VanStockListDto>(ObjectMapper.Map<List<VanStockListDto>>(vanStocks));
        }

        public async override Task<VanStockDto> UpdateAsync(VanStockDto toUpdate)
        {
            var stocks = await Repository.FirstOrDefaultAsync(x => x.ProductId == toUpdate.ProductId && x.VanId == toUpdate.VanId);

            ObjectMapper.Map(toUpdate, stocks);

            await Repository.UpdateAsync(stocks);

            return MapToEntityDto(stocks);
        }
    }
}
