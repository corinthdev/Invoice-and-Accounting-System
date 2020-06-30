using System.Collections.Generic;
using AccountingSystems.Roles.Dto;

namespace AccountingSystems.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}