using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystems.Bookings.Dto
{
    public class BookingUpdateDto : FullAuditedEntityDto<int>
    {
         public int BookingId { get; set; }
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public string InvoiceCode { get; set; }
        public int CustomerId { get; set; }
        public int SalesmanId { get; set; }
        public IEnumerable<BookingDetailDto> BookingDetails { get; set; }
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
        public decimal TotalGross { get; set; }
        public string TotalDiscount { get; set; }
        public decimal TotalNet { get; set; }
        public decimal Vatable { get; set; }
        public decimal TwelvePercentVat { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
