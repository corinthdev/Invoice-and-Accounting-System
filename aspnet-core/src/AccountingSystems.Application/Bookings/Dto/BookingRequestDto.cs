using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Bookings.Dto
{
    public class BookingRequestDto : PagedResultRequestDto
    {
        public string BookingCode { get; set; }
    }
}
