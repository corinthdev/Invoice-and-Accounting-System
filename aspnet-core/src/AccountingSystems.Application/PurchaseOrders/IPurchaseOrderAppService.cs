using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.PurchaseOrders.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.PurchaseOrders
{
    public interface IPurchaseOrderAppService : IAsyncCrudAppService<PurchaseOrderHeaderDto, int, PurchaseOrderRequestDto, CreatePurchaseOrderDto, PurchaseOrderHeaderDto>
    {
        Task<ListResultDto<PurchaseOrderListDto>> GetPurchaseOrder();

        Task<LastPurchaseOrderCode> GetLastPurchaseOrderCode();

        Task<GetPurchaseOrderForEditOutput> GetPurchaseOrderForEdit(EntityDto input);

        Task<PurchaseOrderEditDto> GetPurchaseOrderAsync(int purchaseOrderId);

        Task<ListResultDto<PurchaseOrderListDto>> GetrecentPurchase();
        Task<List<PurchaseOrderEditDto>> GetHeaderToExcel();
    }
}
