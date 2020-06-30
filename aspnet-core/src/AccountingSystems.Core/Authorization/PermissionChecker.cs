using Abp.Authorization;
using AccountingSystems.Authorization.Roles;
using AccountingSystems.Authorization.Users;

namespace AccountingSystems.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
