using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Bookings.Dto
{
    public class BookingEditDto : FullAuditedEntity<int>, IMustHaveTenant
    {
        public int BookingId { get; set; }
        public int TenantId { get; set; }
        public string BookingCode { get; set; }
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress
        {
            get
            {
                return CustomerHouseNumber + " " + CustomerStreet + " " + CustomerBarangay + " " + CustomerMunicipality + ", " + CustomerProvince;
            }
        }
        public string CustomerHouseNumber { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerBarangay { get; set; }
        public string CustomerMunicipality { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerTerms { get; set; }
        public string CustomerDisc1 { get; set; }
        public string CustomerDisc2 { get; set; }
        public string CustomerDisc3 { get; set; }
        public string CustomerDisc4 { get; set; }
        public int SalesmanId { get; set; }
        public string SalesmanCode { get; set; }
        public string SalesmanName { get; set; }
        public int TotalCase { get; set; }
        public int TotalBox { get; set; }
        public int TotalPiece { get; set; }
        public int TotalQuantity
        {
            get
            {
                return TotalCase + TotalBox + TotalPiece;
            }
        }
        public double TotalGross { get; set; }
        public string TotalDiscount { get; set; }
        public double TotalNet { get; set; }
        public double Vatable { get; set; }
        public double TwelvePercentVat { get; set; }
        public DateTime BookingDate { get; set; }
        public IEnumerable<BookingEditDetailsDto> BookingDetails { get; set; }
        public string CreatorUsername { get; set; }
    }
}
