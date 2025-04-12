using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftware_Project
{
    public class LoginPage
    {
        //Interfaces
        private IPage _page;
        ILocator _username;
        ILocator _password;
        ILocator _login_btn;

        public LoginPage(IPage page)
        {
            _page = page;
            _username = _page.Locator("//body/div[@id='mainPanel']/div[@id='bodyPanel']/div[@id='leftPanel']/div[@id='loginPanel']/form[1]/div[1]/input[1]");
            _password = _page.Locator("//body/div[@id='mainPanel']/div[@id='bodyPanel']/div[@id='leftPanel']/div[@id='loginPanel']/form[1]/div[2]/input[1]");
            _login_btn = _page.Locator("//body/div[@id='mainPanel']/div[@id='bodyPanel']/div[@id='leftPanel']/div[@id='loginPanel']/form[1]/div[3]/input[1]");
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

        public async Task ValidateSuccessfullLogin()
        {
            Assert.That(await _page.InnerTextAsync("//h1[normalize-space()='Accounts Overview']"), Is.EqualTo("Accounts Overview"));
        }
    }
}