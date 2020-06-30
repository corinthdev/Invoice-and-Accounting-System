using Abp.Application.Services;
using AccountingSystems.Bookings.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Bookings
{
    public interface IBookingDetailsAppService : IAsyncCrudAppService<BookingDetailDto, int, BookingDetailDto, BookingDetailDto, BookingDetailDto>
    {
        Task<List<BookingDetailDto>> GetBookingDetails();
        Task<BookingEditDetailsDto> GetDetailsAsync(int bookingHeaderId);
        Task<List<BookingEditDetailsDto>> GetDetailsToExcel();
    }
}
