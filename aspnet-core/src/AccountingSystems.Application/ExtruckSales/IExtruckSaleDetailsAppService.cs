using Abp.Application.Services;
using AccountingSystems.ExtruckSales.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.ExtruckSales
{
    public interface IExtruckSaleDetailsAppService : IAsyncCrudAppService<ExtruckSaleDetailDto, int, ExtruckSaleDetailDto, ExtruckSaleDetailDto, ExtruckSaleDetailDto>
    {
    }
}
