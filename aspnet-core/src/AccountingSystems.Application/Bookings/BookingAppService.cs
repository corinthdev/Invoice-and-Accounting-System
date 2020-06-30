using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AccountingSystems.BookingDetails;
using AccountingSystems.BookingHeaders;
using AccountingSystems.Bookings.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystems.Bookings
{
    public class BookingAppService : AsyncCrudAppService<BookingHeader, BookingHeaderDto, int, BookingHeaderDto, CreateBookingDto, BookingHeaderDto>, IBookingAppService
    {
        private readonly IRepository<BookingDetail> _bookingDetailRepository;
        public BookingAppService(
        IRepository<BookingDetail> bookingDetailRepository,
        IRepository<BookingHeader, int> repository) 
            : base(repository)
        {
            _bookingDetailRepository = bookingDetailRepository;
        }

        public async override Task<BookingHeaderDto> CreateAsync(CreateBookingDto input)
        {
            var header = await Repository.FirstOrDefaultAsync(x => x.BookingCode == input.BookingCode);
            if (header != null)
                throw new UserFriendlyException("The code is already in use.");

            return await base.CreateAsync(input);
        }
        public async Task<ListResultDto<BookingListDto>> GetBooking()
        {
            var bookings = await Repository
                .GetAll()
                .Include(x => x.Customer)
                .Include(y => y.Salesman)
                .ToListAsync();

            return new ListResultDto<BookingListDto>(ObjectMapper.Map<List<BookingListDto>>(bookings));
        }

        public async override Task<BookingHeaderDto> UpdateAsync(BookingHeaderDto dto)
        {
            var bookings = new BookingHeaderDto
            {
                Id = dto.BookingId,
                TenantId = dto.TenantId,
                BookingCode = dto.BookingCode,
                CustomerId = dto.CustomerId,
                SalesmanId = dto.SalesmanId,
                TotalCase = dto.TotalCase,
                TotalBox = dto.TotalBox,
                TotalPiece = dto.TotalPiece,
                TotalGross = dto.TotalGross,
                TotalDiscount = dto.TotalDiscount,
                TotalNet = dto.TotalNet,
                Vatable = dto.Vatable,
                TwelvePercentVat = dto.TwelvePercentVat,
                BookingDate = dto.BookingDate,
                CreatorUsername = dto.CreatorUsername
            };
            var header = await Repository.GetAsync(dto.BookingId);
            ObjectMapper.Map(bookings, header);
            await CurrentUnitOfWork.SaveChangesAsync();
            //await Repository.UpdateAsync(header);

            var output = await Repository.GetAllIncluding(x => x.Customer, x => x.Salesman)
                                       .FirstOrDefaultAsync(x => x.BookingCode == dto.BookingCode);

            return MapToEntityDto(output);
        }

        public async Task<LastBookingCode> GetLastBookingCode()
        {
            var output = await Repository
                .GetAll()
                .OrderBy(x => x.CreationTime)
                .LastOrDefaultAsync();

            var outputCode = ObjectMapper.Map<BookingRequestDto>(output);

            if (output == null)
                return null;

            return new LastBookingCode
            {
                BookingCode = outputCode.BookingCode
            };
        }

        public async Task<GetBookingForEditOutput> GetBookingForEdit(EntityDto input)
        {
            var result = new BookingEditDto();
            var header = await Repository
                .GetAllIncluding(x => x.Customer, x => x.Salesman)
                .FirstOrDefaultAsync(x => x.Id == input.Id);

            if (header != null)
            {
                ObjectMapper.Map(header, result);
                var details = await _bookingDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.BookingHeaderId == header.Id)
                                                           .ToListAsync();

                result.BookingDetails = ObjectMapper.Map<List<BookingEditDetailsDto>>(details);
            }

            var bookingEditDto = ObjectMapper.Map<BookingEditDto>(result);
            return new GetBookingForEditOutput
            {
                BookingEdit = bookingEditDto
            };
        }

        public async Task<BookingEditDto> GetBookingAsync(int bookingId)
        {
            var result = new BookingEditDto();
            var booking = await Repository
                .GetAllIncluding(x => x.Customer, x => x.Salesman)
                .FirstOrDefaultAsync(x => x.Id == bookingId);
            if (booking != null)
            {
                ObjectMapper.Map(booking, result);
                var details = await _bookingDetailRepository.GetAll()
                                                           .Include(x => x.Product)
                                                           .Where(x => x.BookingHeaderId == booking.Id)
                                                           .ToListAsync();

                result.BookingDetails = ObjectMapper.Map<List<BookingEditDetailsDto>>(details);
            }

            return result;
        }

        public async Task<List<BookingEditDto>> GetHeaderToExcel()
        {
            var headers = await Repository
                .GetAllIncluding(x => x.Customer, y => y.Salesman)
                .ToListAsync();

            return new List<BookingEditDto>(ObjectMapper.Map<List<BookingEditDto>>(headers));
        }
    }
}
