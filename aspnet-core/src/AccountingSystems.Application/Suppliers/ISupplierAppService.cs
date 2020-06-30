using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.Salesmans.Dto;
using AccountingSystems.Suppliers.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Suppliers
{
    public interface ISupplierAppService : IAsyncCrudAppService<SupplierDto, int, PagedSupplierResultRequestDto, CreateSupplierDto, SupplierDto>
    {
        Task<ListResultDto<SupplierListDto>> GetSupplier();
        Task<GetSupplierForEditOutput> GetSupplierForEdit(EntityDto input);
        Task<GetSupplierNameOutput> GetSupplierName(string supplierCode);
        Task<GetTotalSupplier> GetTotalSupplier();
        Task<List<SupplierListDto>> GetSupplierToExcel();
    }
}
