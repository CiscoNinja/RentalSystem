using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RentalSystem.Authorization;

namespace RentalSystem
{
    [DependsOn(
        typeof(RentalSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class RentalSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<RentalSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(RentalSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
