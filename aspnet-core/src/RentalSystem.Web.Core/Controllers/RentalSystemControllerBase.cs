using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace RentalSystem.Controllers
{
    public abstract class RentalSystemControllerBase: AbpController
    {
        protected RentalSystemControllerBase()
        {
            LocalizationSourceName = RentalSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
