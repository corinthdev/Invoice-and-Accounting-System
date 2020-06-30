using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.Vans;
using AccountingSystems.Salesmans.Dto;
using AccountingSystems.Vans.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Vans
{
    public class VanAppService : AsyncCrudAppService<Van, VanDto, int, PagedVanResultRequestDto, CreateVanDto, VanDto>, IVanAppService
    {
        private readonly IRepository<Van> _vanRepository;
        public VanAppService(IRepository<Van, int> repository, IRepository<Van> vanRepository) 
            : base(repository)
        {
            _vanRepository = vanRepository;
        }

        public override async Task<VanDto> CreateAsync(CreateVanDto input)
        {
            var hasVan = await _vanRepository.FirstOrDefaultAsync(x => x.Code == input.Code);
            if (hasVan != null)
            {
                throw new UserFriendlyException("There is already a Van with given van code");
            }
            var vans = ObjectMapper.Map<Van>(input);
            await _vanRepository.InsertAsync(vans);
            return MapToEntityDto(vans);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var vans = await _vanRepository.GetAsync(input.Id);
            await _vanRepository.DeleteAsync(vans);
        }
        public override async Task<VanDto> GetAsync(EntityDto<int> input)
        {
            var vans = await Repository
                .GetAll()
                .Include(t => t.Salesman)
                .FirstOrDefaultAsync(x => x.Id == input.Id);
            return MapToEntityDto(vans);
        }
        public async Task<ListResultDto<VanListDto>> GetVan()
        {
            var vans = await _vanRepository
                .GetAll()
                .Include(t => t.Salesman)
                .ToListAsync();
            return new ListResultDto<VanListDto>(ObjectMapper.Map<List<VanListDto>>(vans));
        }

        public async Task<GetVanForEditOutput> GetVanForEdit(EntityDto input)
        {
            var van = await _vanRepository
                .GetAll()
                .Include(t => t.Salesman)
                .FirstOrDefaultAsync(x => x.Id == input.Id);
            var vanEditDto = ObjectMapper.Map<VanEditDto>(van);

            return new GetVanForEditOutput
            {
                VanEdit = vanEditDto
            };
        }

        public async Task<GetVanNameForOutput> GetVAnName(string vanCode)
        {
            var vanName = await _vanRepository.GetAll().FirstOrDefaultAsync(x => x.Code == vanCode);
            var vanDto = ObjectMapper.Map<VanEditDto>(vanName);

            return new GetVanNameForOutput
            {
                Id = vanDto.Id,
                Name = vanDto.Name
            };
        }

        public async Task<List<VanListDto>> GetVanToExcel()
        {
            var vans = await Repository.GetAllListAsync();

            return new List<VanListDto>(ObjectMapper.Map<List<VanListDto>>(vans));
        }

        public override async Task<VanDto> UpdateAsync(VanDto input)
        {
            var van = await _vanRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, van);

            await _vanRepository.UpdateAsync(van);
            return MapToEntityDto(van);
        }
    }
}
