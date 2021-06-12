using System.Threading.Tasks;
using RentalSystem.Models.TokenAuth;
using RentalSystem.Web.Controllers;
using Shouldly;
using Xunit;

namespace RentalSystem.Web.Tests.Controllers
{
    public class HomeController_Tests: RentalSystemWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}