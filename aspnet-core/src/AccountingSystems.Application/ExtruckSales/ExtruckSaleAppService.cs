using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.ExtruckSaleDetails;
using AccountingSystems.ExtruckSaleHeaders;
using AccountingSystems.ExtruckSales.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.ExtruckSales
{
    public class ExtruckSaleAppService : AsyncCrudAppService<ExtruckSaleHeader, ExtruckHeaderDto, int, ExtruckSaleRequestDto, ExtruckHeaderDto, ExtruckHeaderDto>, IExtruckSaleAppService
    {
        private readonly IRepository<ExtruckSaleDetail> _extruckSaleDetailRepository;
        public ExtruckSaleAppService(
        IRepository<ExtruckSaleDetail> extruckSaleDetailRepository,
        IRepository<ExtruckSaleHeader, int> repository) 
            : base(repository)
        {
            _extruckSaleDetailRepository = extruckSaleDetailRepository;
        }
        public override async Task<ExtruckHeaderDto> CreateAsync(ExtruckHeaderDto dto)
        {
            var header = await Repository.FirstOrDefaultAsync(x => x.ExtruckSaleCode == dto.ExtruckSaleCode);

            if (header != null)
                throw new UserFriendlyException("The code is already in use.");

            return await base.CreateAsync(dto);
        }

        public async Task<ExtruckHeaderDto> GetByCodeAsync(string dto)
        {
            var result = await Repository.GetAllIncluding(x => x.Customer, x => x.Salesman)
                                         .FirstOrDefaultAsync(x => x.ExtruckSaleCode == dto);


            return MapToEntityDto(result);
        }

        public async Task<ListResultDto<ExtruckSaleListDto>> GetExtruckSale()
        {
            var extruckSales = await Repository
                .GetAll()
                .Include(x => x.Customer)
                .Include(y => y.Salesman)
                .ToListAsync();
            return new ListResultDto<ExtruckSaleListDto>(ObjectMapper.Map<List<ExtruckSaleListDto>>(extruckSales));
        }

        public override async Task<ExtruckHeaderDto> UpdateAsync(ExtruckHeaderDto dto)
        {

            var invoices = new ExtruckHeaderDto
            {
                Id = dto.ExtruckSaleId,
                TenantId = dto.TenantId,
                ExtruckSaleCode = dto.ExtruckSaleCode,
                CustomerId = dto.CustomerId,
                SalesmanId = dto.SalesmanId,
                TotalCase = dto.TotalCase,
                TotalBox = dto.TotalBox,
                TotalPiece = dto.TotalPiece,
                TotalGross = dto.TotalGross,
                TotalDiscount = dto.TotalDiscount,
                TotalNet = dto.TotalNet,
                Vatable = dto.Vatable,
                TwelvePercentVat = dto.TwelvePercentVat,
                ExtruckSaleDate = dto.ExtruckSaleDate,
                ExtruckSaleDetails = dto.ExtruckSaleDetails,
                CreatorUsername = dto.CreatorUsername
            };
            var header = await Repository.GetAsync(dto.ExtruckSaleId);

            ObjectMapper.Map(invoices, header);

            //await CurrentUnitOfWork.SaveChangesAsync();
            await Repository.UpdateAsync(header);
            var output = await Repository.GetAllIncluding(x => x.Customer, x => x.Salesman)
                                         .FirstOrDefaultAsync(x => x.ExtruckSaleCode == dto.ExtruckSaleCode);
            return MapToEntityDto(output);
        }

        public async Task<GetExtruckSaleForEditOutput> GetExtruckSaleForEdit(EntityDto input)
        {
            var result = new ExtruckSaleEditDto();
            var header = await Repository
                .GetAllIncluding(x => x.Customer, x => x.Salesman)
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (header != null)
            {
                ObjectMapper.Map(header, result);
                var details = await _extruckSaleDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.ExtruckSaleHeaderId == header.Id)
                                                           .ToListAsync();

                result.ExtruckSaleDetails = ObjectMapper.Map<List<ExtruckSaleEditDetailsDto>>(details);
            }

            var extruckSaleEditDto = ObjectMapper.Map<ExtruckSaleEditDto>(result);
            return new GetExtruckSaleForEditOutput
            {
                ExtruckSaleEdit = extruckSaleEditDto
            };
        }
    }
}
