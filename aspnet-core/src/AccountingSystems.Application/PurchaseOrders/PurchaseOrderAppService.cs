using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.Managers;
using AccountingSystems.PurchaseOrderDetails;
using AccountingSystems.PurchaseOrderHeaders;
using AccountingSystems.PurchaseOrders.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.PurchaseOrders
{
    public class PurchaseOrderAppService : AsyncCrudAppService<PurchaseOrderHeader, PurchaseOrderHeaderDto, int, PurchaseOrderRequestDto, CreatePurchaseOrderDto, PurchaseOrderHeaderDto>, IPurchaseOrderAppService
    {
        IRepository<PurchaseOrderDetail> _purchaseOrderDetailRepository;
        public PurchaseOrderAppService(
        IRepository<PurchaseOrderDetail> purchaseOrderDetailRepository,
        IRepository<PurchaseOrderHeader, int> repository) : base(repository)
        {
            _purchaseOrderDetailRepository = purchaseOrderDetailRepository;
        }

        public override async Task<PurchaseOrderHeaderDto> CreateAsync(CreatePurchaseOrderDto dto)
        {
            var header = await Repository.FirstOrDefaultAsync(x => x.PurchaseOrderCode == dto.PurchaseOrderCode);

            if (header != null)
                throw new UserFriendlyException("The code is already in use.");

            return await base.CreateAsync(dto);
        }

        public async Task<PurchaseOrderHeaderDto> GetByCodeAsync(string dto)
        {
            var result = await Repository.GetAllIncluding(x => x.Supplier)
                                         .FirstOrDefaultAsync(x => x.PurchaseOrderCode == dto);

            return MapToEntityDto(result);
        }
        public async Task<ListResultDto<PurchaseOrderListDto>> GetPurchaseOrder()
        {
            var purchaseOrders = await Repository
                .GetAll()
                .Include(x => x.Supplier)
                .ToListAsync();
            return new ListResultDto<PurchaseOrderListDto>(ObjectMapper.Map<List<PurchaseOrderListDto>>(purchaseOrders));
        }
        public override async Task<PurchaseOrderHeaderDto> UpdateAsync(PurchaseOrderHeaderDto dto)
        {
            var purchaseOders = new PurchaseOrderHeaderDto
            {
                Id = dto.PurchaseOrderId,
                TenantId = dto.TenantId,
                PurchaseOrderCode = dto.PurchaseOrderCode,
                SupplierId = dto.SupplierId,
                TotalCase = dto.TotalCase,
                TotalBox = dto.TotalBox,
                TotalPiece = dto.TotalPiece,
                TotalGross = dto.TotalGross,
                TotalDiscount = dto.TotalDiscount,
                TotalNet = dto.TotalNet,
                Vatable = dto.Vatable,
                TwelvePercentVat = dto.TwelvePercentVat,
                PurchaseDate = dto.PurchaseDate,
                CreatorUsername = dto.CreatorUsername
            };
            var header = await Repository.GetAsync(dto.PurchaseOrderId);

            ObjectMapper.Map(purchaseOders, header);

            await CurrentUnitOfWork.SaveChangesAsync();
            //await Repository.UpdateAsync(header);
            var output = await Repository.GetAllIncluding(x => x.Supplier)
                                         .FirstOrDefaultAsync(x => x.PurchaseOrderCode == dto.PurchaseOrderCode);
            return MapToEntityDto(output);
        }
        public async Task<LastPurchaseOrderCode> GetLastPurchaseOrderCode()
        {
            var output = await Repository
                .GetAll()
                .OrderBy(x => x.CreationTime)
                .LastOrDefaultAsync();

            var outputCode = ObjectMapper.Map<PurchaseOrderRequestDto>(output);

            if (output == null)
            {
                return null;
            }

            return new LastPurchaseOrderCode
            {
                PurchaseOrderCode = outputCode.PurchaseOrderCode
            };
        }

        public async Task<GetPurchaseOrderForEditOutput> GetPurchaseOrderForEdit(EntityDto input)
        {
            var result = new PurchaseOrderEditDto();
            var header = await Repository
                .GetAllIncluding(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (header != null)
            {
                ObjectMapper.Map(header, result);
                var details = await _purchaseOrderDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.PurchaseOrderHeaderId == header.Id)
                                                           .ToListAsync();

                result.PurchaseOrderDetails = ObjectMapper.Map<List<PurchaseOrderEditDetailsDto>>(details);
            }

            var purchaseOrderEditDto = ObjectMapper.Map<PurchaseOrderEditDto>(result);
            return new GetPurchaseOrderForEditOutput
            {
                PurchaseOrderEdit = purchaseOrderEditDto
            };
        }
        public async Task<PurchaseOrderEditDto> GetPurchaseOrderAsync(int purchaseOrderId)
        {
            var result = new PurchaseOrderEditDto();
            var purchase = await Repository
                .GetAllIncluding(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.Id == purchaseOrderId);
            if (purchase != null)
            {
                ObjectMapper.Map(purchase, result);
                var details = await _purchaseOrderDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.PurchaseOrderHeaderId == purchase.Id)
                                                           .ToListAsync();

                result.PurchaseOrderDetails = ObjectMapper.Map<List<PurchaseOrderEditDetailsDto>>(details);
            }

            return result;
        }

        public async Task<ListResultDto<PurchaseOrderListDto>> GetrecentPurchase()
        {
            var recent = await Repository
                .GetAllIncluding(x => x.Supplier)
                .OrderByDescending(x => x.CreationTime)
                .ToListAsync();

            var lastFive = recent.Take(5);

            return new ListResultDto<PurchaseOrderListDto>(ObjectMapper.Map<List<PurchaseOrderListDto>>(lastFive));
        }

        public async Task<List<PurchaseOrderEditDto>> GetHeaderToExcel()
        {
            var headers = await Repository
                .GetAllIncluding(x => x.Supplier)
                .ToListAsync();

            return new List<PurchaseOrderEditDto>(ObjectMapper.Map<List<PurchaseOrderEditDto>>(headers));
        }
    }
}
