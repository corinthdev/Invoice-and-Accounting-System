using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingSystems.PurchaseOrderDetails;
using AccountingSystems.PurchaseOrders.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.PurchaseOrders
{
    public class PurchaseOrderDetailsAppService : AsyncCrudAppService<PurchaseOrderDetail, PurchaseOrderDetailDto, int, PurchaseOrderDetailDto, PurchaseOrderDetailDto, PurchaseOrderDetailDto>, IPurchaseOrderDetailsAppService
    {
        public PurchaseOrderDetailsAppService(IRepository<PurchaseOrderDetail, int> repository) 
            : base(repository)
        {
        }
        public async override Task DeleteAsync(EntityDto<int> input)
        {
            var details = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(details);
        }

        public async Task<PurchaseOrderEditDetailsDto> GetDetailsAsync(int purchaseOrderHeaderId)
        {
            var purchaseDetails = await Repository.FirstOrDefaultAsync(x => x.Id == purchaseOrderHeaderId);
            if (purchaseDetails == null)
                return null;

            return new PurchaseOrderEditDetailsDto
            {
                TotalPieces = purchaseDetails.TotalPieces
            };
        }
        public async override Task<PurchaseOrderDetailDto> GetAsync(EntityDto<int> input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (details == null)
                return null;

            return MapToEntityDto(details);
        }
        public async override Task<PurchaseOrderDetailDto> UpdateAsync(PurchaseOrderDetailDto input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            ObjectMapper.Map(input, details);

            await Repository.UpdateAsync(details);
            return MapToEntityDto(details);
        }

        public async Task<List<PurchaseOrderEditDetailsDto>> GetDetailsToExcel()
        {
            var details = await Repository
                .GetAllIncluding(x => x.PurchaseOrderHeader, y => y.Product)
                .ToListAsync();

            return new List<PurchaseOrderEditDetailsDto>(ObjectMapper.Map<List<PurchaseOrderEditDetailsDto>>(details));
        }
    }
}
