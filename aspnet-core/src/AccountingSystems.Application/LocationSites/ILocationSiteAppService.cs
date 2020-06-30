using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.LocationSites.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.LocationSites
{
    public interface ILocationSiteAppService : IAsyncCrudAppService<LocationSiteDto, int, LocationSiteDto, LocationSiteDto, LocationSiteDto>
    {
        Task<ListResultDto<LocationSiteDto>> GetLocationSite();
        Task<List<LocationSiteDto>> GetSupplierToExcel();
        Task<GetLocationSiteForEditOutput> GetForEdit(EntityDto entityDto);
    }
}
