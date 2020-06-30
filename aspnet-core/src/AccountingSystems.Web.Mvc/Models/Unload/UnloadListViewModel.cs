using AccountingSystems.Unloads.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.Unload
{
    public class UnloadListViewModel
    {
        public IReadOnlyList<UnloadListDto> Unloads { get; set; }
    }
}
