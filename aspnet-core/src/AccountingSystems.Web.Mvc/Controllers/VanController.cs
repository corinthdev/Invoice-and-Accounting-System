using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using AccountingSystems.Controllers;
using AccountingSystems.Salesmans;
using AccountingSystems.Vans;
using AccountingSystems.Vans.Dto;
using AccountingSystems.Web.Models.Vans;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystems.Web.Mvc.Controllers
{
    public class VanController : AccountingSystemsControllerBase
    {
        private readonly IVanAppService _vanService;
        private readonly ISalesmanAppService _salesmanService;
        public VanController(IVanAppService vanService, ISalesmanAppService salesmanService)
        {
            _vanService = vanService;
            _salesmanService = salesmanService;
        }
        public async Task<ActionResult> Index()
        {
            var vans = (await _vanService.GetVan()).Items;
            var salesman = (await _salesmanService.GetSalesman()).Items;
            var model = new VanListViewModel
            {
                Vans = vans,
                Salesmen = salesman
            };
            return View(model);
        }

        public async Task<ActionResult> EditVanModal(int vanId)
        {
            var output = await _vanService.GetVanForEdit(new EntityDto(vanId));
            var salesman = (await _salesmanService.GetSalesman()).Items;
            var model = new EditVanModalViewModel
            {
                VanEdit = output,
                Salesmen = salesman
            };

            return View("_EditVanModal", model);
        }

        public async Task<ActionResult> GetVanName(string vanCode)
        {
            var output = await _vanService.GetVAnName(vanCode);
            var model = ObjectMapper.Map<GetVanNameForOutput>(output);

            return Ok(model);
        }
    }
}