using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using AccountingSystems.Bookings;
using AccountingSystems.Bookings.Dto;
using AccountingSystems.Controllers;
using AccountingSystems.Customers;
using AccountingSystems.Products;
using AccountingSystems.Sessions;
using AccountingSystems.Stocks;
using AccountingSystems.Stocks.Dto;
using AccountingSystems.Web.Models.Bookings;
using AccountingSystems.Web.Models.Transaction;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Mvc.Controllers
{
    [AbpMvcAuthorize]
    public class BookingController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly ICustomerAppService _customerService;
        private readonly IProductAppService _productService;
        private readonly IBookingAppService _bookingService;
        private readonly IBookingDetailsAppService _bookingDetailsService;
        private readonly IStockAppService _stockService;

        public BookingController(ISessionAppService sessionAppService,
                                 ICustomerAppService customerService, 
                                 IProductAppService productService,
                                 IBookingAppService bookingService,
                                 IBookingDetailsAppService bookingDetailsService,
                                 IStockAppService stockService
                                 )
        {
            _sessionAppService = sessionAppService;
            _customerService = customerService;
            _productService = productService;
            _bookingService = bookingService;
            _bookingDetailsService = bookingDetailsService;
            _stockService = stockService;
        }
        public async Task<ActionResult> Index()
        {
            var bookings = (await _bookingService.GetBooking()).Items;
            var model = new BookingListViewModel
            {
                BookingLists = bookings
            };
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var customers = (await _customerService.GetCustomer()).Items;
            var products = (await _productService.GetProduct()).Items;

            var model = new CreateBookingViewModel
            {
                Customers = customers,
                Products = products,
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
            };
            return View("Create", model);
        }
        [HttpPost]
        public async Task<ActionResult> CreateBooking(CreateBookingDto dto)
        {
            await _bookingService.CreateAsync(dto);

            foreach (var items in dto.BookingDetails)
            {
                var check = await _stockService.CheckIfExist(items.ProductId);
                if (check != null)
                {
                    check.TotalPieces -= items.TotalPieces;
                    check.Amount -= items.Amount;
                    await _stockService.UpdateAsync(check);
                }

            }

            return Ok(dto);
        }
        public async Task<ActionResult> View(int bookingId)
        {
            var model = new ViewBookingViewModel
            {
                BookingEdit = await _bookingService.GetBookingForEdit(new EntityDto(bookingId)),
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };
            return View("View", model);
        }
        public async Task<ActionResult> Print(int bookingId)
        {
            var model = new ViewBookingViewModel
            {
                BookingEdit = await _bookingService.GetBookingForEdit(new EntityDto(bookingId)),
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };
            return View("Print", model);
        }
        public async Task<ActionResult> Edit(int bookingId)
        {
            var invoice = await _bookingService.GetBookingForEdit(new EntityDto(bookingId));
            var model = ObjectMapper.Map<EditBookingViewModel>(invoice);
            return View("Edit", model);
        }
        [HttpPost]
        public async Task<ActionResult> EditBooking(BookingHeaderDto dto)
        {
            foreach (var dtoItem in dto.BookingDetails)
            {
                var check = await _stockService.CheckIfExist(dtoItem.ProductId);
                var old = await _bookingDetailsService.GetDetailsAsync(dtoItem.Id);
                if (old != null)
                {
                    if (dtoItem.TotalPieces > old.TotalPieces)
                    {
                        var change = dtoItem.TotalPieces - old.TotalPieces;
                        var tAmount = dtoItem.PricePerPiece * change;
                        check.TotalPieces -= change;
                        check.Amount -= tAmount;

                        await _stockService.UpdateAsync(check);
                    }
                    else if (dtoItem.TotalPieces < old.TotalPieces)
                    {
                        var change = old.TotalPieces - dtoItem.TotalPieces;
                        var tAmount = dtoItem.PricePerPiece * change;
                        check.TotalPieces += change;
                        check.Amount += tAmount;

                        await _stockService.UpdateAsync(check);
                    }

                }
                else
                {
                    check.TotalPieces -= dtoItem.TotalPieces;
                    check.Amount -= dtoItem.Amount;

                    await _stockService.UpdateAsync(check);
                }
            }

            var updated = await _bookingService.UpdateAsync(dto);
            foreach (var items in dto.BookingDetails)
            {
                var getCheck = await _bookingDetailsService.GetAsync(new EntityDto<int>(items.Id));
                if (getCheck == null)
                {
                    var toCreate = new BookingDetailDto
                    {
                        BookingHeaderId = dto.BookingId,
                        ProductId = items.ProductId,
                        Case = items.Case,
                        ProdCase = items.ProdCase,
                        Box = items.Box,
                        ProdPiece = items.ProdPiece,
                        Piece = items.Piece,
                        Gross = items.Gross,
                        Discount = items.Discount,
                        Net = items.Net,
                        TotalProductPrice = items.TotalProductPrice,
                    };
                    await _bookingDetailsService.CreateAsync(toCreate);

                }
                else if (getCheck != null)
                {
                    var toUpdate = new BookingDetailDto
                    {
                        Id = items.Id,
                        CreationTime = items.CreationTime,
                        CreatorUserId = items.CreatorUserId,
                        TenantId = items.TenantId,
                        BookingHeaderId = items.BookingHeaderId,
                        ProductId = items.ProductId,
                        Case = items.Case,
                        ProdCase = items.ProdCase,
                        Box = items.Box,
                        ProdPiece = items.ProdPiece,
                        Piece = items.Piece,
                        Gross = items.Gross,
                        Discount = items.Discount,
                        Net = items.Net,
                        TotalProductPrice = items.TotalProductPrice,
                    };
                    await _bookingDetailsService.UpdateAsync(toUpdate);
                }
            }

            return Ok(updated);
        }
        public async Task<ActionResult> GetLastBookingCode()
        {
            var invoice = await _bookingService.GetLastBookingCode();
            var model = ObjectMapper.Map<GetLastBookingViewModel>(invoice);

            return Ok(model);
        }
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var header = await _bookingService.GetHeaderToExcel();
            var details = await _bookingDetailsService.GetDetailsToExcel();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Headers");
                var ws2 = excel.Workbook.Worksheets.Add("Details");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;

                ws.Cells["A5"].Value = "Booking_No";
                ws.Cells["B5"].Value = "Cus_Name";
                ws.Cells["C5"].Value = "Salesman_Code";
                ws.Cells["D5"].Value = "T_Case";
                ws.Cells["E5"].Value = "T_Box";
                ws.Cells["F5"].Value = "T_Pieces";
                ws.Cells["G5"].Value = "T_Amount";
                ws.Cells["H5"].Value = "Terms";
                ws.Cells["I5"].Value = "Date";
                int rowStart = 6;
                foreach (var item in header)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.BookingCode;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.CustomerName;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.SalesmanCode;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.TotalCase;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.TotalBox;
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.TotalPiece;
                    ws.Cells[string.Format("G{0}", rowStart)].Value = item.TotalNet;
                    ws.Cells[string.Format("H{0}", rowStart)].Value = item.CustomerTerms;
                    ws.Cells[string.Format("I{0}", rowStart)].Value = item.BookingDate;
                    ws.Cells[string.Format("I{0}", rowStart)].Style.Numberformat.Format = "mm/dd/yyyy";

                    rowStart++;
                }

                ws.Cells["A:AZ"].AutoFitColumns();

                ws2.Cells["A1"].Value = currentTenant.Tenant.Name;

                ws2.Cells["A3"].Value = "Trans_No";
                ws2.Cells["B3"].Value = "Prod_Code";
                ws2.Cells["C3"].Value = "Trans_Date";
                ws2.Cells["D3"].Value = "Qty_Case";
                ws2.Cells["E3"].Value = "Qty_Box";
                ws2.Cells["F3"].Value = "Qty_Pieces";
                ws2.Cells["G3"].Value = "Sale_Price";
                ws2.Cells["H3"].Value = "Amount";

                int rowStart1 = 4;
                foreach (var item in details)
                {
                    ws2.Cells[string.Format("A{0}", rowStart1)].Value = item.BookingHeaderBookingCode;
                    ws2.Cells[string.Format("B{0}", rowStart1)].Value = item.ProductCode;
                    ws2.Cells[string.Format("C{0}", rowStart1)].Value = item.CreationTime;
                    ws2.Cells[string.Format("C{0}", rowStart1)].Style.Numberformat.Format = "mm/dd/yyyy";
                    ws2.Cells[string.Format("D{0}", rowStart1)].Value = item.Case;
                    ws2.Cells[string.Format("E{0}", rowStart1)].Value = item.Box;
                    ws2.Cells[string.Format("F{0}", rowStart1)].Value = item.Piece;
                    ws2.Cells[string.Format("G{0}", rowStart1)].Value = item.TotalProductPrice;
                    ws2.Cells[string.Format("H{0}", rowStart1)].Value = item.Net;

                    rowStart1++;
                }
                ws2.Cells["A:AZ"].AutoFitColumns();

                fileContents = excel.GetAsByteArray();
            }
            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }
            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Bookings.xlsx"
            );
        }
    }
}