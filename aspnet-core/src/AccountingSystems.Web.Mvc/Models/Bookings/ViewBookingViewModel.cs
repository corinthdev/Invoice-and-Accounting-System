using Abp.AutoMapper;
using AccountingSystems.Bookings.Dto;
using AccountingSystems.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Bookings
{
    public class ViewBookingViewModel
    {
        public GetBookingForEditOutput BookingEdit { get; set; }
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}
