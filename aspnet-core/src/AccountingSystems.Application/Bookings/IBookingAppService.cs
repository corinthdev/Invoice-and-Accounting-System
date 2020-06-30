using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.Bookings.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Bookings
{
    public interface IBookingAppService : IAsyncCrudAppService<BookingHeaderDto, int, BookingHeaderDto, CreateBookingDto, BookingHeaderDto>
    {
        Task<ListResultDto<BookingListDto>> GetBooking();
        Task<LastBookingCode> GetLastBookingCode();
        Task<GetBookingForEditOutput> GetBookingForEdit(EntityDto input);
        Task<BookingEditDto> GetBookingAsync(int bookingId);
        Task<List<BookingEditDto>> GetHeaderToExcel();
    }
}
