using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.Salesmans;
using AccountingSystems.Salesmans.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Salesmans
{
    public class SalesmanAppService : AsyncCrudAppService<Salesman, SalesmanDto, int, PagedSalesmanResultRequestDto, CreateSalesmanDto, SalesmanDto>, ISalesmanAppService
    {
        public SalesmanAppService(IRepository<Salesman, int> repository) 
            : base(repository)
        {
        }

        public override async Task<SalesmanDto> CreateAsync(CreateSalesmanDto input)
        {
            var hasSalesman = await Repository.FirstOrDefaultAsync(x => x.Code == input.Code);
            if (hasSalesman != null)
            {
                throw new UserFriendlyException("There is already a Salesman with given salesman code");
            }
            var salesman = ObjectMapper.Map<Salesman>(input);
            await Repository.InsertAsync(salesman);
            return MapToEntityDto(salesman);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var salesman = await Repository.GetAsync(input.Id);
            await Repository.DeleteAsync(salesman);
        }

        public async Task<ListResultDto<SalesmanListDto>> GetSalesman()
        {
            var salesman = await Repository.GetAllListAsync();
            return new ListResultDto<SalesmanListDto>(ObjectMapper.Map<List<SalesmanListDto>>(salesman));
        }

        public async Task<GetSalesmanForEditOutput> GetSalesmanForEdit(EntityDto input)
        {
            var salesman = await Repository.GetAll().FirstOrDefaultAsync(x => x.Id == input.Id);
            var salesmEditDto = ObjectMapper.Map<SalesmanEditDto>(salesman);
            return new GetSalesmanForEditOutput
            {
                SalesmanEdit = salesmEditDto
            };
        }
        
        public async Task<GetSalesmanNameOutput> GetSalesmanName(string salesmanCode)
        {
            var salesmanName = await Repository.GetAll().FirstOrDefaultAsync(x => x.Code == salesmanCode);
            var salesmanDto = ObjectMapper.Map<SalesmanEditDto>(salesmanName);

            return new GetSalesmanNameOutput
            {
                Id = salesmanDto.Id,
                Name = salesmanDto.Name
            };
        }

        public override async Task<SalesmanDto> UpdateAsync(SalesmanDto input)
        {
            var salesman = await Repository.GetAsync(input.Id);
            ObjectMapper.Map(input, salesman);

            await Repository.UpdateAsync(salesman);

            return MapToEntityDto(salesman);
        }
        public async Task<GetTotalSalesman> GetTotalSalesman()
        {
            var total = await Repository.GetAll().CountAsync();

            return new GetTotalSalesman
            {
                TotalSalesman = total
            };
        }

        public async Task<List<SalesmanListDto>> GetSalesmanToExcel()
        {
            var salesman = await Repository.GetAllListAsync();
            return new List<SalesmanListDto>(ObjectMapper.Map<List<SalesmanListDto>>(salesman));
        }
    }
}
