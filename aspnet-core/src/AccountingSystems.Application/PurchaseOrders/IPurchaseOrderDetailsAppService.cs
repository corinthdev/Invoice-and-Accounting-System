using Abp.Application.Services;
using AccountingSystems.PurchaseOrders.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.PurchaseOrders
{
    public interface IPurchaseOrderDetailsAppService : IAsyncCrudAppService<PurchaseOrderDetailDto, int, PurchaseOrderDetailDto, PurchaseOrderDetailDto, PurchaseOrderDetailDto>
    {
        Task<PurchaseOrderEditDetailsDto> GetDetailsAsync(int purchaseOrderHeaderId);
        Task<List<PurchaseOrderEditDetailsDto>> GetDetailsToExcel();
    }
}
