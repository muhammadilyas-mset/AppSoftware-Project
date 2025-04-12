using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftware_Project
{
    public class IncorrectLoginPage
    {
        //Interfaces
        private IPage _page;
        ILocator _username;
        ILocator _password;
        ILocator _login_btn;

        public IncorrectLoginPage(IPage page)
        {
            _page = page;
            _username = _page.Locator("//input[@data-qa='login-email']");
            _password = _page.Locator("//input[@placeholder='Password']");
            _login_btn = _page.Locator("//button[normalize-space()='Login']");
        }

        public async Task GoToURL(string Url)
        {
            await _page.GotoAsync(Url);
        }

        public async Task LoginMethod(string username, string password)
        {
            await _username.FillAsync(username);
            await _password.FillAsync(password);
            await _login_btn.ClickAsync();
        }

        public async Task ValidateUnSuccessfullLogin()
        {
            Assert.That(await _page.InnerTextAsync("//p[@class='error']"), Is.EquivalentTo("The username and password could not be verified."));
        }
    }
}