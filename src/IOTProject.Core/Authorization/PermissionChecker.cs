using Abp.Authorization;
using IOTProject.Authorization.Roles;
using IOTProject.Authorization.Users;

namespace IOTProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
