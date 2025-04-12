using AppSoftware_Project;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace SignUpAutomationExc.Tests
{
    public class LoginPageTest : TestBase
    {
        [Test, Order(1)]
        public async Task Test1()
        {
            var correctLoginPage = new LoginPage(_page);
            await correctLoginPage.GoToURL("https://parabank.parasoft.com/parabank/index.htm");
            await correctLoginPage.LoginMethod("ilyas@gmail.com", "Parents1!");
            await correctLoginPage.ValidateSuccessfullLogin();
        }
    }
}
