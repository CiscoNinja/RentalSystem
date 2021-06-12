using Abp.Authorization;
using RentalSystem.Authorization.Roles;
using RentalSystem.Authorization.Users;

namespace RentalSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
