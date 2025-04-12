using Microsoft.Playwright;
using System.Threading.Tasks;

namespace AppSoftware_Project
{
    public class LogOutPage
    {
        private IPage _page;
        private ILocator _emailInput;
        private ILocator _passwordInput;
        private ILocator _loginButton;
        private ILocator _logoutButton;

        public LogOutPage(IPage page)
        {
            _page = page;
            _emailInput = _page.Locator("//input[@name='username']");
            _passwordInput = _page.Locator("//input[@name='password']");
            _loginButton = _page.Locator("//input[@value='Log In']");
            _logoutButton = _page.Locator("//a[normalize-space()='Log Out']");
        }

        public async Task GoToURL(string url)
        {
            await _page.GotoAsync(url);
        }

        public async Task LoginMethod(string email, string password)
        {
            await _emailInput.FillAsync(email);
            await _passwordInput.FillAsync(password);
            await _loginButton.ClickAsync();
        }

        public async Task LogOut()
        {
            await _logoutButton.ClickAsync();
        }

        public async Task ValidateSuccessfullLogOut()
        {
            var isLoggedOut = await _page.IsVisibleAsync("//input[@value='Log In']");
            if (!isLoggedOut)
            {
                throw new Exception("Log out was not successful!");
            }
        }
    }
}
