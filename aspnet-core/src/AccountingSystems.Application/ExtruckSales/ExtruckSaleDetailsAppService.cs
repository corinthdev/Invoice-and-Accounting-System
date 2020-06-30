using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingSystems.ExtruckSaleDetails;
using AccountingSystems.ExtruckSales.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.ExtruckSales
{
    public class ExtruckSaleDetailsAppService : AsyncCrudAppService<ExtruckSaleDetail, ExtruckSaleDetailDto, int, ExtruckSaleDetailDto, ExtruckSaleDetailDto, ExtruckSaleDetailDto>, IExtruckSaleDetailsAppService
    {
        public ExtruckSaleDetailsAppService(IRepository<ExtruckSaleDetail, int> repository) 
            : base(repository)
        {
        }
        public async override Task DeleteAsync(EntityDto<int> input)
        {
            var extruckSaleDetails = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(extruckSaleDetails);
        }
    }
}
