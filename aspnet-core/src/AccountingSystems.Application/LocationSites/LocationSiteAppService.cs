using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.LocationSites.Dto;
using AccountingSystems.Sites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.LocationSites
{
    public class LocationSiteAppService : AsyncCrudAppService<LocationSite, LocationSiteDto, int, LocationSiteDto, LocationSiteDto, LocationSiteDto>, ILocationSiteAppService
    {
        public LocationSiteAppService(IRepository<LocationSite, int> repository) 
            : base(repository)
        {
        }

        public async override Task<LocationSiteDto> CreateAsync(LocationSiteDto input)
        {
            var locSite = await Repository.FirstOrDefaultAsync(x => x.SiteCode == input.SiteCode);
            if(locSite != null)
            {
                throw new UserFriendlyException("There is already a Site with given Site code");
            }
            return await base.CreateAsync(input);
        }
        public async override Task DeleteAsync(EntityDto<int> input)
        {
            var locSite = await Repository.GetAsync(input.Id);
            await Repository.DeleteAsync(locSite);
        }

        public async Task<GetLocationSiteForEditOutput> GetForEdit(EntityDto entityDto)
        {
            var locSite = await Repository.GetAll().FirstOrDefaultAsync(x => x.Id == entityDto.Id);
            var dto = ObjectMapper.Map<LocationSiteDto>(locSite);

            return new GetLocationSiteForEditOutput
            {
                LocationSite = dto
            };
        }

        public async Task<ListResultDto<LocationSiteDto>> GetLocationSite()
        {
            var locSite = await Repository.GetAllListAsync();

            return new ListResultDto<LocationSiteDto>(ObjectMapper.Map<List<LocationSiteDto>>(locSite));
        }

        public async Task<List<LocationSiteDto>> GetSupplierToExcel()
        {
            var locSite = await Repository.GetAllListAsync();

            return new List<LocationSiteDto>(ObjectMapper.Map<List<LocationSiteDto>>(locSite));
        }

        public async override Task<LocationSiteDto> UpdateAsync(LocationSiteDto input)
        {
            var locSite = await Repository.GetAsync(input.Id);
            ObjectMapper.Map(input, locSite);

            await Repository.UpdateAsync(locSite);

            return MapToEntityDto(locSite);
        }
    }
}
