using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Bookings.Dto
{
    public class BookingListDto : FullAuditedEntity<int>
    {
        public string BookingCode { get; set; }

        public string CustomerName { get; set; }

        public string CustomerHouseNumber { get; set; }

        public string CustomerStreet { get; set; }

        public string CustomerBarangay { get; set; }

        public string CustomerMunicipality { get; set; }

        public string CustomerProvince { get; set; }

        public string SalesmanName { get; set; }

        public DateTime BookingDate { get; set; }

        public string CreatorUsername { get; set; }
    }
}
