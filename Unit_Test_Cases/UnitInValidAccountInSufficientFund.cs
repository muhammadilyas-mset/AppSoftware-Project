using Microsoft.Playwright;
using System.Threading.Tasks;

namespace AppSoftware_Project.Tests
{
    public class UnitInValidAccountInSufficientFund
    {
        private IPage _page;
        private OpenNewAccount _openNewAccount;

        public UnitInValidAccountInSufficientFund()
        {
            var playwright = Playwright.CreateAsync().Result;
            var browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            }).Result;
            var context = browser.NewContextAsync().Result;
            _page = context.NewPageAsync().Result;

            _openNewAccount = new OpenNewAccount(_page);
        }

        [Test]
        public async Task Test_GoToURL()
        {
            string url = "https://parabank.parasoft.com/parabank/openaccount.htm"; // Use your actual URL here

            await _openNewAccount.GoToURL(url);

            Assert.That(_page.Url, Is.EqualTo(url));

        }

        [Test]
        public async Task Test_LoginMethod()
        {
            string username = "ilyas@gmail.com";
            string password = "Parents1!";


            await _openNewAccount.LoginAsync(username, password);
            await _openNewAccount.OpenNewAccountAsync("SAVINGS", "137887", "$1000.00");
            await _openNewAccount.OpenNewAccountAsync("CHECKING", "137887", "$1000.00");

            bool isLoginSuccessful = await _page.IsVisibleAsync("//div[@id='accountCreatedMessage']");
            Assert.True(isLoginSuccessful);
        }

        public async Task DisposeAsync()
        {
            await _page.CloseAsync();
        }
    }
}
