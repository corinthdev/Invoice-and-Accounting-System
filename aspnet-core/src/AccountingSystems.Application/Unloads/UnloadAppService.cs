using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingSystems.UnloadDetails;
using AccountingSystems.UnloadHeaders;
using AccountingSystems.Unloads.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Unloads
{
    public class UnloadAppService : AsyncCrudAppService<UnloadHeader, UnloadHeaderDto, int, UnloadHeaderDto, CreateUnloadDto, UnloadHeaderDto>, IUnloadAppService
    {
        private readonly IRepository<UnloadDetail> _unloadRepository;
        public UnloadAppService(
        IRepository<UnloadDetail> unloadRepository,
        IRepository<UnloadHeader, int> repository) 
            : base(repository)
        {
            _unloadRepository = unloadRepository;
        }
        public async override Task<UnloadHeaderDto> CreateAsync(CreateUnloadDto input)
        {
            return await base.CreateAsync(input);
        }

        public async Task<List<UnloadEditDto>> GetHeaderToExcel()
        {
            var headers = await Repository
                .GetAllIncluding(x => x.Van, y => y.Salesman)
                .ToListAsync();

            return new List<UnloadEditDto>(ObjectMapper.Map<List<UnloadEditDto>>(headers));
        }

        public async Task<LastUnloadCode> GetLastUnloadCode()
        {
            var output = await Repository
               .GetAll()
               .OrderBy(x => x.CreationTime)
               .LastOrDefaultAsync();

            var outputCode = ObjectMapper.Map<UnloadRequestDto>(output);

            if (output == null)
                return null;

            return new LastUnloadCode
            {
                UnloadCode = outputCode.UnloadCode
            };
        }

        public async Task<ListResultDto<UnloadListDto>> GetUnload()
        {
            var unload = await Repository
                .GetAll()
                .Include(x => x.Van)
                .Include(y => y.Salesman)
                .ToListAsync();
            return new ListResultDto<UnloadListDto>(ObjectMapper.Map<List<UnloadListDto>>(unload));
        }

        public async Task<UnloadEditDto> GetUnloadAsync(int withdrawalId)
        {
            var result = new UnloadEditDto();
            var header = await Repository
                .GetAllIncluding(x => x.Van, x => x.Salesman)
                .FirstOrDefaultAsync(x => x.Id == withdrawalId);
            if (header != null)
            {
                ObjectMapper.Map(header, result);
                var details = await _unloadRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.UnloadHeaderId == header.Id)
                                                           .ToListAsync();

                result.UnloadDetails = ObjectMapper.Map<List<UnloadEditDetailsDto>>(details);
            }

            return result;
        }

        public async Task<GetUnloadForEditOutput> GetUnloadForEdit(EntityDto input)
        {
            var result = new UnloadEditDto();
            var header = await Repository
                .GetAllIncluding(x => x.Van, x => x.Salesman)
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (header != null)
            {
                ObjectMapper.Map(header, result);
                var details = await _unloadRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.UnloadHeaderId == header.Id)
                                                           .ToListAsync();

                result.UnloadDetails = ObjectMapper.Map<List<UnloadEditDetailsDto>>(details);
            }

            var dto = ObjectMapper.Map<UnloadEditDto>(result);
            return new GetUnloadForEditOutput
            {
                UnloadEdit = dto
            };
        }
        public async override Task<UnloadHeaderDto> UpdateAsync(UnloadHeaderDto dto)
        {
            var unloads = new UnloadHeaderDto
            {
                Id = dto.UnloadId,
                TenantId = dto.TenantId,
                UnloadCode = dto.UnloadCode,
                VanId = dto.VanId,
                SalesmanId = dto.SalesmanId,
                TotalCase = dto.TotalCase,
                TotalBox = dto.TotalBox,
                TotalPiece = dto.TotalPiece,
                TotalGross = dto.TotalGross,
                TotalDiscount = dto.TotalDiscount,
                TotalNet = dto.TotalNet,
                Vatable = dto.Vatable,
                TwelvePercentVat = dto.TwelvePercentVat,
                UnloadDate = dto.UnloadDate,
                CreatorUsername = dto.CreatorUsername
            };
            var header = await Repository.GetAsync(dto.UnloadId);
            ObjectMapper.Map(unloads, header);

            await CurrentUnitOfWork.SaveChangesAsync();
            //await Repository.UpdateAsync(header);
            var output = await Repository.GetAllIncluding(x => x.Van, x => x.Salesman)
                                         .FirstOrDefaultAsync(x => x.UnloadCode == dto.UnloadCode);
            return MapToEntityDto(output);
        }
    }
}
