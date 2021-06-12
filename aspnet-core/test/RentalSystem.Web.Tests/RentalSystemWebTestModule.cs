using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RentalSystem.EntityFrameworkCore;
using RentalSystem.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace RentalSystem.Web.Tests
{
    [DependsOn(
        typeof(RentalSystemWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class RentalSystemWebTestModule : AbpModule
    {
        public RentalSystemWebTestModule(RentalSystemEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RentalSystemWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(RentalSystemWebMvcModule).Assembly);
        }
    }
}