using Abp.AutoMapper;
using AccountingSystems.RetailsEnvironments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystems.Web.Models.RetailEnvironments
{
    [AutoMapFrom(typeof(GetRetailEnvironmentForEditOutput))]
    public class EditRetailEnvironmentModalViewModel : GetRetailEnvironmentForEditOutput
    {
    }
}
