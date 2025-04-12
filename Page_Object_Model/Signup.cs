using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SignUpAutomationExc
{
    public class SignupPage
    {
        private IPage _page;
        private ILocator _name;
        private ILocator _SSN;
        private ILocator _password;
        private ILocator _FirstName;
        private ILocator _LastName;
        private ILocator _ConfirmPassword;
        private ILocator _Address;
        private ILocator _state;
        private ILocator _City;
        private ILocator _zipcode;
        private ILocator _mobilenumber;
        private ILocator _SignUp_btn;
    //    private ILocator _CreateAccount_btn;

        public SignupPage(IPage page)
        {
            _page = page;
            _FirstName = _page.Locator("//input[@id='customer.firstName']");
            _LastName = _page.Locator("//input[@id='customer.lastName']");
            _Address = _page.Locator("//input[@id='customer.address.street']");
            _City = _page.Locator("//input[@id='customer.address.city']");
            _state = _page.Locator("//input[@id='customer.address.state']");
            _zipcode = _page.Locator("//input[@id='customer.address.zipCode']");
            _mobilenumber = _page.Locator("//input[@id='customer.phoneNumber']");
            _SSN = _page.Locator("//input[@id='customer.ssn']");
            _name = _page.Locator("//input[@id='customer.username']");
            _password = _page.Locator("//input[@id='customer.password']");
            _ConfirmPassword = _page.Locator("//input[@id='repeatedPassword']");
            _SignUp_btn = _page.Locator("//tbody/tr[13]/td[2]/input[1]");
    //        _CreateAccount_btn = _page.Locator("button[data-qa='create-account']");
        }

        public async Task GoToURL(string Url)
        {
            await _page.GotoAsync(Url);
        }

        public async Task SignUpMethod(
            string username,
            string SSN,
            string password,
            string FirstName,
            string LastName,
            string ConfirmPassword,
            string Address,
            string state,
            string City,
            string zipcode,
            string mobilenumber)
        {
            await _name.FillAsync(username); // Corrected from _username
            await _password.FillAsync(password);
            await _ConfirmPassword.FillAsync(ConfirmPassword);
            await _SSN.FillAsync(SSN);
            await _FirstName.FillAsync(FirstName);
            await _LastName.FillAsync(LastName);
            await _Address.FillAsync(Address);
            await _state.FillAsync(state);
            await _City.FillAsync(City);
            await _zipcode.FillAsync(zipcode);
            await _mobilenumber.FillAsync(mobilenumber);
            await _SignUp_btn.ClickAsync();

        //    await _CreateAccount_btn.ClickAsync();
        }

        public async Task ValidateSuccessfullLogin()
        {
            Assert.That(await _page.InnerTextAsync("//p[contains(text(),'Your account was created successfully. You are now')]"), Is.EquivalentTo("Your account was created successfully. You are now logged in."));
        }

        public async Task ValidateUnSuccessfullLogin()
        {
            Assert.That(await _page.InnerTextAsync("//span[@id='customer.address.city.errors']"), Is.EqualTo("Address is required."));
        }
    }
}
