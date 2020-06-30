using Abp.AutoMapper;
using AccountingSystems.Salesmans.Dto;
using AccountingSystems.Vans.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Vans
{
    public class EditVanModalViewModel
    {
        public GetVanForEditOutput VanEdit { get; set; }
        public IReadOnlyList<SalesmanListDto> Salesmen { get; set; }
    }
}
