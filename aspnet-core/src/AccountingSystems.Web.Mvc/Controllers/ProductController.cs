using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AccountingSystems.Controllers;
using AccountingSystems.Products;
using AccountingSystems.Sessions;
using AccountingSystems.Suppliers;
using AccountingSystems.Web.Models.Products;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AccountingSystems.Web.Mvc.Controllers
{
    public class ProductController : AccountingSystemsControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IProductAppService _productService;
        private readonly ISupplierAppService _supplierService;

        public ProductController(ISessionAppService sessionAppService,
                                 IProductAppService productService,
                                 ISupplierAppService supplierService
                                )
        {
            _sessionAppService = sessionAppService;
            _productService = productService;
            _supplierService = supplierService;

        }

        public async Task<ActionResult> Index()
        {
            var products = (await _productService.GetProduct()).Items;
            var suppliers = (await _supplierService.GetSupplier()).Items;
            var model = new ProductListViewModel
            {
                ProductLists = products,
                SupplierLists = suppliers
            };

            return View(model);
        }
        public async Task<ActionResult> Print()
        {
            var model = new PrintProductViewModel
            {
                Products = await _productService.GetAllProduct(),
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };

            return View(model);
        }
        public async Task<ActionResult> EditProductModal(int productId)
        {
            var output = await _productService.GetProductForEdit(new EntityDto(productId));
            var suppliers = (await _supplierService.GetSupplier()).Items;
            var model = new EditProductModalViewModel
            {
                ProductEdit = output,
                Suppliers = suppliers
            };

            return View("_EditProductModal", model);
        }
        public async Task<IActionResult> ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            byte[] fileContents;
            var products = await _productService.GetAllProduct();
            var currentTenant = await _sessionAppService.GetCurrentLoginInformations();

            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("Products");
                ws.Cells["A1"].Value = currentTenant.Tenant.Name;
                ws.Cells["A2"].Value = "List of Products";

                ws.Cells["A5"].Value = "Prod_SupCode";
                ws.Cells["B5"].Value = "Prod_Code";
                ws.Cells["C5"].Value = "Prod_Description";
                ws.Cells["D5"].Value = "Prod_Case";
                ws.Cells["E5"].Value = "Prod_Box";
                ws.Cells["F5"].Value = "Prod_Piece";
                ws.Cells["G5"].Value = "Prod_Gross";
                ws.Cells["H5"].Value = "Prod_Freight";
                ws.Cells["I5"].Value = "Prod_Discount";
                ws.Cells["J5"].Value = "Prod_Vat";
                ws.Cells["K5"].Value = "Prod_PercentagePM";
                ws.Cells["L5"].Value = "Prod_PriceMargin";
                ws.Cells["M5"].Value = "Prod_PriceA";
                ws.Cells["N5"].Value = "Prod_PriceB";
                ws.Cells["O5"].Value = "Prod_PriceC";
                ws.Cells["P5"].Value = "Prod_PriceD";
                ws.Cells["Q5"].Value = "Prod_PriceE";
                ws.Cells["R5"].Value = "Prod_PriceF";
                ws.Cells["S5"].Value = "Prod_Brand";
                ws.Cells["T5"].Value = "Prod_BarcodeCase";
                ws.Cells["U5"].Value = "Prod_BarcodeItem";

                int rowStart = 6;
                foreach (var item in products)
                {
                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.SuppliersCode;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.Code;
                    ws.Cells[string.Format("C{0}", rowStart)].Value = item.ItemName;
                    ws.Cells[string.Format("D{0}", rowStart)].Value = item.Cases;
                    ws.Cells[string.Format("E{0}", rowStart)].Value = item.Box;
                    ws.Cells[string.Format("F{0}", rowStart)].Value = item.Pieces;
                    ws.Cells[string.Format("G{0}", rowStart)].Value = item.GrossPrice;
                    ws.Cells[string.Format("H{0}", rowStart)].Value = item.Freight;
                    ws.Cells[string.Format("I{0}", rowStart)].Value = item.Discount;
                    ws.Cells[string.Format("J{0}", rowStart)].Value = item.Vat;
                    ws.Cells[string.Format("K{0}", rowStart)].Value = item.PercentagePriceMargin;
                    ws.Cells[string.Format("L{0}", rowStart)].Value = item.PricePerBox;
                    ws.Cells[string.Format("M{0}", rowStart)].Value = item.PriceA;
                    ws.Cells[string.Format("N{0}", rowStart)].Value = item.PriceB;
                    ws.Cells[string.Format("O{0}", rowStart)].Value = item.PriceC;
                    ws.Cells[string.Format("P{0}", rowStart)].Value = item.PriceD;
                    ws.Cells[string.Format("Q{0}", rowStart)].Value = item.PriceE;
                    ws.Cells[string.Format("R{0}", rowStart)].Value = item.PriceF;
                    ws.Cells[string.Format("S{0}", rowStart)].Value = item.Brand;
                    ws.Cells[string.Format("T{0}", rowStart)].Value = item.BarcodeCase;
                    ws.Cells[string.Format("U{0}", rowStart)].Value = item.BarcodeItem;

                    rowStart++;
                }

                ws.Cells["A:AZ"].AutoFitColumns();

                fileContents = excel.GetAsByteArray();
            }
            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }
            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: "Products.xlsx"
            );
        }

    }
}