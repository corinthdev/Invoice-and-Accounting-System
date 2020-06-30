using AccountingSystems.Bookings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Bookings
{
    public class BookingListViewModel
    {
        public IReadOnlyList<BookingListDto> BookingLists { get; set; }
    }
}
