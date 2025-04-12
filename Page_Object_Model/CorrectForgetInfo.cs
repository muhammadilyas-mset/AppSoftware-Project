using Microsoft.Playwright;
using System.Threading.Tasks;

namespace AppSoftware_Project

{
    public class correct_ForgetInfo_f
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
        private ILocator _FindInfo_btn;
        //private ILocator _CreateAccount_btn;

        public correct_ForgetInfo_f(IPage page)
        {
            _page = page;
            _FirstName = _page.Locator("customer.firstName");
            _LastName = _page.Locator("customer.lastName");
            _Address = _page.Locator("customer.address.street");
            _City = _page.Locator("customer.address.city");
            _state = _page.Locator("customer.address.state");
            _zipcode = _page.Locator("customer.address.zipCode");
            _SSN = _page.Locator("customer.ssn");
            _FindInfo_btn = _page.Locator("//input[@value='Find My Login Info']");
        }

        public async Task GoToURL(string Url)
        {
            await _page.GotoAsync(Url);
        }

        public async Task correctForgetMethod(
            string SSN,
            string FirstName,
            string LastName,
            string Address,
            string state,
            string City,
            string zipcode)
        {
            await _SSN.FillAsync(SSN);
            await _FirstName.FillAsync(FirstName);
            await _LastName.FillAsync(LastName);
            await _Address.FillAsync(Address);
            await _state.FillAsync(state);
            await _City.FillAsync(City);
            await _zipcode.FillAsync(zipcode);
            await _FindInfo_btn.ClickAsync();

        }

    public async Task ValidateSuccessfullLogin()
        {
            Assert.That(await _page.InnerTextAsync("//p[contains(text(),'Your login information was located successfully. Y')]"), Is.EquivalentTo("Your login information was located successfully. You are now logged in."));
        }
    }
}
