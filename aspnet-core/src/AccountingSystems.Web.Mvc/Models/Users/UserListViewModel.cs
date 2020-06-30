using System.Collections.Generic;
using AccountingSystems.Roles.Dto;
using AccountingSystems.Users.Dto;

namespace AccountingSystems.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
