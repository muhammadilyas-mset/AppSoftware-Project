using Microsoft.Playwright;
using NUnit.Framework;
using AppSoftware_Project;

namespace SignUpAutomationExc.Tests
{
    public class LogOutPageTests
    {
        private IBrowser _browser;
        private IPage _page;

        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            _page = await _browser.NewPageAsync();
        }

        [Test]
        public async Task TestLogOut()
        {
            // Arrange
            var logOutPage = new LogOutPage(_page);

            // Act
            await logOutPage.GoToURL("https://parabank.parasoft.com/parabank/index.htm");
            await logOutPage.LoginMethod("ilyas@gmail.com", "Parents1!");
            await logOutPage.LogOut();

            // Assert
            Assert.DoesNotThrowAsync(async () => await logOutPage.ValidateSuccessfullLogOut());
        }

        [TearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
        }
    }
}
