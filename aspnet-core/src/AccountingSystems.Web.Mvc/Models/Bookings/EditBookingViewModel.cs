using Abp.AutoMapper;
using AccountingSystems.Bookings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Bookings
{
    [AutoMapFrom(typeof(GetBookingForEditOutput))]
    public class EditBookingViewModel : GetBookingForEditOutput
    {
    }
}
