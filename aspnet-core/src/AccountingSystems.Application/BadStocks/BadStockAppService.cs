using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.BadStocks.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.BadStocks
{
    public class BadStockAppService : AsyncCrudAppService<BadStock, BadStockDto, int, BadStockDto, BadStockDto, BadStockDto>, IBadStockAppService
    {
        public BadStockAppService(IRepository<BadStock, int> repository) 
            : base(repository)
        {
        }
        public async Task<BadStockDto> CheckAvailable(int productId, int totalPieces)
        {
            var available = await Repository.FirstOrDefaultAsync(x => x.ProductId == productId && x.TotalPieces >= totalPieces);
            if (available == null)
                throw new UserFriendlyException("Insufficient stock for item");

            return MapToEntityDto(available);
        }
        public async Task<BadStockDto> CheckIfExist(int productId)
        {
            var stock = await Repository.FirstOrDefaultAsync(x => x.ProductId == productId);

            return MapToEntityDto(stock);
        }

        public async override Task<BadStockDto> CreateAsync(BadStockDto input)
        {
            return await base.CreateAsync(input);
        }

        public async Task<ListResultDto<BadStockListDto>> GetStocks()
        {
            var stocks = await Repository
                .GetAll()
                .Include(x => x.Product)
                .ToListAsync();

            return new ListResultDto<BadStockListDto>(ObjectMapper.Map<List<BadStockListDto>>(stocks));
        }

        public async override Task<BadStockDto> UpdateAsync(BadStockDto input)
        {
            var stocks = await Repository.FirstOrDefaultAsync(x => x.ProductId == input.ProductId);

            ObjectMapper.Map(input, stocks);

            await Repository.UpdateAsync(stocks);

            return MapToEntityDto(stocks);
        }

        public async Task<GetTotalBadStocks> GetTotal()
        {
            var stocks = await Repository.GetAllListAsync();

            var allPiece = stocks.Sum(x => x.TotalPieces);

            double totalAmount = stocks.Sum(x => x.Amount);

            return new GetTotalBadStocks
            {
                AllPieces = allPiece,
                AllAmount = totalAmount
            };
        }

        public async Task<List<BadStockListDto>> ExportToExcel()
        {
            var stocks = await Repository
                .GetAllIncluding(x => x.Product)
                .ToListAsync();

            return new List<BadStockListDto>(ObjectMapper.Map<List<BadStockListDto>>(stocks));
        }
    }
}
