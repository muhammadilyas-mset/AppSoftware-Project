using Microsoft.Playwright;
using SignUpAutomationExc.Tests;
using System.Threading.Tasks;

namespace AppSoftware_Project.Tests
{
    public class UnitValidAccountZeroOrNegativeSufficientFund : LoginPageTest
    {


        [Test,Order(2)]
        public async Task Test_GoToURL()
        {
            var openNewAccount = new OpenNewAccount(_page);
            string url = "https://parabank.parasoft.com/parabank/openaccount.htm"; // Use your actual URL here

            await openNewAccount.GoToURL(url);

            Assert.That(_page.Url, Is.EqualTo(url));

        }

        [Test, Order(3)]
        public async Task Test_LoginMethod()
        {
            string username = "ilyas@gmail.com";
            string password = "Parents1!";

            var openNewAccount = new OpenNewAccount(_page);

            await openNewAccount.LoginAsync(username, password);
            await openNewAccount.OpenNewAccountAsync("SAVINGS", "13788", "$00.00");
            await openNewAccount.OpenNewAccountAsync("CHECKING", "13788", "$00.00");

            bool isLoginSuccessful = await _page.IsVisibleAsync("//div[@id='accountCreatedMessage']");
            Assert.True(isLoginSuccessful);
        }

        public async Task DisposeAsync()
        {
            await _page.CloseAsync();
        }
    }
}
