using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.Suppliers;
using AccountingSystems.Salesmans.Dto;
using AccountingSystems.Suppliers.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Suppliers
{
    public class SupplierAppService : AsyncCrudAppService<Supplier, SupplierDto, int, PagedSupplierResultRequestDto, CreateSupplierDto, SupplierDto>, ISupplierAppService
    {
        public SupplierAppService(IRepository<Supplier, int> repository) 
            : base(repository)
        {
        }

        public override async Task<SupplierDto> CreateAsync(CreateSupplierDto input)
        {
            var hasSupplier = await Repository.FirstOrDefaultAsync(x => x.Code == input.Code);
            if (hasSupplier != null)
            {
                throw new UserFriendlyException("There is already a Supplier with given supplier code");
            }
            var supplier = ObjectMapper.Map<Supplier>(input);
            await Repository.InsertAsync(supplier);
            return MapToEntityDto(supplier);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var supplier = await Repository.GetAsync(input.Id);
            await Repository.DeleteAsync(supplier);
        }

        public async Task<ListResultDto<SupplierListDto>> GetSupplier()
        {
            var suppliers = await Repository.GetAllListAsync();
            return new ListResultDto<SupplierListDto>(ObjectMapper.Map<List<SupplierListDto>>(suppliers));
        }

        public async Task<GetSupplierForEditOutput> GetSupplierForEdit(EntityDto input)
        {
            var supplier = await Repository.GetAll().FirstOrDefaultAsync(x => x.Id == input.Id);
            var supplierEditDto = ObjectMapper.Map<SupplierEditDto>(supplier);

            return new GetSupplierForEditOutput
            {
                SupplierEdit = supplierEditDto
            };
        }

        public async Task<GetSupplierNameOutput> GetSupplierName(string supplierCode)
        {
            var supplierName = await Repository.GetAll().FirstOrDefaultAsync(x => x.Code == supplierCode);
            var supplierDto = ObjectMapper.Map<SupplierEditDto>(supplierName);

            return new GetSupplierNameOutput
            {
                Id = supplierDto.Id,
                Name = supplierDto.Name
            };
        }

        public async Task<List<SupplierListDto>> GetSupplierToExcel()
        {
            var suppliers = await Repository.GetAllListAsync();
            return new List<SupplierListDto>(ObjectMapper.Map<List<SupplierListDto>>(suppliers));
        }

        public async Task<GetTotalSupplier> GetTotalSupplier()
        {
            var total = await Repository.GetAll().CountAsync();

            return new GetTotalSupplier
            {
                TotalSupplier = total
            };
        }

        public override async Task<SupplierDto> UpdateAsync(SupplierDto input)
        {
            var supplier = await Repository.GetAsync(input.Id);
            ObjectMapper.Map(input, supplier);

            await Repository.UpdateAsync(supplier);
            return MapToEntityDto(supplier);
        }
    }
}
