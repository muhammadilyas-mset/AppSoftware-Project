using Microsoft.Playwright;
using AppSoftware_Project;
using SignUpAutomationExc;


namespace SignUpAutomationExc.Tests
{
    public class LoginTest
    {


        [Test]
        public async Task Test1()
        {
            var _playwright = await Playwright.CreateAsync();
            var _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set true for headless mode
            });

            //Open Browser

            var page = await _browser.NewPageAsync();
            var loginPage = new IncorrectLoginPage(page);
            await loginPage.GoToURL("https://parabank.parasoft.com/parabank/index.htm");
            await loginPage.LoginMethod("testuserOsama@example.comz", "Password123!");
            await loginPage.ValidateUnSuccessfullLogin();
        }
    }
}


