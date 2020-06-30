using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AccountingSystems.BookingDetails;
using AccountingSystems.Bookings.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Bookings
{
    public class BookingDetailsAppService : AsyncCrudAppService<BookingDetail, BookingDetailDto, int, BookingDetailDto, BookingDetailDto, BookingDetailDto>, IBookingDetailsAppService
    {
        public BookingDetailsAppService(IRepository<BookingDetail, int> repository) 
            : base(repository)
        {
        }

        public async override Task DeleteAsync(EntityDto<int> input)
        {
            var bookingDetails = await Repository.GetAsync(input.Id);

            await Repository.DeleteAsync(bookingDetails);
        }
        public async Task<BookingEditDetailsDto> GetDetailsAsync(int bookingHeaderId)
        {
            var bookingDetails = await Repository.FirstOrDefaultAsync(x => x.Id == bookingHeaderId);
            if (bookingDetails == null)
                return null;

            return new BookingEditDetailsDto
            {
                TotalPieces = bookingDetails.TotalPieces
            };
        }
        public async override Task<BookingDetailDto> GetAsync(EntityDto<int> input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (details == null)
                return null;

            return MapToEntityDto(details);
        }
        public async Task<List<BookingDetailDto>> GetBookingDetails()
        {
            var bookingDetails = await Repository
                .GetAllListAsync();

            return new List<BookingDetailDto>(ObjectMapper.Map<List<BookingDetailDto>>(bookingDetails));
        }
        public async override Task<BookingDetailDto> UpdateAsync(BookingDetailDto input)
        {
            var details = await Repository.FirstOrDefaultAsync(x => x.Id == input.Id);
            ObjectMapper.Map(input, details);

            await Repository.UpdateAsync(details);
            return MapToEntityDto(details);
        }

        public async Task<List<BookingEditDetailsDto>> GetDetailsToExcel()
        {
            var details = await Repository
                .GetAllIncluding(x => x.BookingHeader, y => y.Product)
                .ToListAsync();

            return new List<BookingEditDetailsDto>(ObjectMapper.Map<List<BookingEditDetailsDto>>(details));
        }
    }
}
