using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AccountingSystems.InvoiceDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountingSystems.Invoices.Dto
{
    public class InvoiceDetailDto :FullAuditedEntityDto<int>, IMustHaveTenant, IPassivable
    {
        public int TenantId { get; set; }
        public bool IsActive { get; set; }
        public int InvoiceHeaderId { get; set; }
        public double PricePerPiece { get; set; }
        public int ProductId { get; set; }
        public int Case { get; set; }
        public int ProdCase { get; set; }
        public int Box { get; set; }
        public int ProdPiece { get; set; }
        public int Piece { get; set; }
        public double TotalProductPrice { get; set; }
        public double Gross { get; set; }
        public string Discount { get; set; }
        public double Net { get; set; }
        public int TotalPieces
        {
            get
            {
                return (Case * ProdCase) + (Box * ProdPiece) + Piece;
            }
        }
        public double Amount
        {
            get
            {
                return TotalPieces * PricePerPiece;
            }
        }

    }
}
