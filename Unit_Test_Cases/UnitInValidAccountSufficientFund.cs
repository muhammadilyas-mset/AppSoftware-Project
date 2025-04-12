using Microsoft.Playwright;
using SignUpAutomationExc.Tests;
using System.Threading.Tasks;

namespace AppSoftware_Project.Tests
{
    public class UnitInValidAccountSufficientFund : LoginPageTest
    {
        private OpenNewAccount _openNewAccount;

        [SetUp]
        public async Task Setup() { 
            _openNewAccount = new OpenNewAccount(_page);
        }

        [Test,Order(2)]
        public async Task Test_GoToURL()
        {
            string url = "https://parabank.parasoft.com/parabank/openaccount.htm"; // Use your actual URL here

            await _openNewAccount.GoToURL(url);

            Assert.That(_page.Url, Is.EqualTo(url));
        
        }

        [Test,Order(3)]
        public async Task Test_LoginMethod()
        {
            string username = "ilyas@gmail.com";
            string password = "Parents1!";

           
            await _openNewAccount.LoginAsync(username, password);
            await _openNewAccount.OpenNewAccountAsync("SAVINGS", "13788", "$100.00");
            await _openNewAccount.OpenNewAccountAsync("CHECKING", "13788", "$100.00");

            bool isLoginSuccessful = await _page.IsVisibleAsync("//div[@id='accountCreatedMessage']");
            Assert.IsFalse(isLoginSuccessful);
        }

        public async Task DisposeAsync()
        {
            await _page.CloseAsync();
        }
    }
}
