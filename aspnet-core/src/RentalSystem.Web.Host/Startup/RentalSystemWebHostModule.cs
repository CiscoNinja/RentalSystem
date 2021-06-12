using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RentalSystem.Configuration;

namespace RentalSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(RentalSystemWebCoreModule))]
    public class RentalSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public RentalSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RentalSystemWebHostModule).GetAssembly());
        }
    }
}
