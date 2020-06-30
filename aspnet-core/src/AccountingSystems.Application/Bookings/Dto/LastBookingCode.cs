using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Bookings.Dto
{
    public class LastBookingCode : FullAuditedEntity<int>
    {
        public string BookingCode { get; set; }
    }
}
