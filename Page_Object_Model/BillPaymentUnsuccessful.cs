using Microsoft.Playwright;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AppSoftware_Project
{
    public class BillPaymentUnsuccessful
    {
        private IPage _page;
        private ILocator _payeeName;
        private ILocator _address;
        private ILocator _city;
        private ILocator _state;
        private ILocator _zipCode;
        private ILocator _phone;
        private ILocator _accountNumber;
        private ILocator _verifyAccount;
        private ILocator _amount;
        private ILocator _fromAccount;
        private ILocator _sendPaymentBtn;

        public BillPaymentUnsuccessful(IPage page)
        {
            _page = page;
            _payeeName = _page.Locator("//input[@name='payee.name']");
            _address = _page.Locator("//input[@name='payee.address.street']");
            _city = _page.Locator("//input[@name='payee.address.city']");
            _state = _page.Locator("//input[@name='payee.address.state']");
            _zipCode = _page.Locator("//input[@name='payee.address.zipCode']");
            _phone = _page.Locator("//input[@id='3ac4ff09-e300-474d-bf21-af20026cbb9d']");
            _accountNumber = _page.Locator("//input[@name='payee.accountNumber']");
            _verifyAccount = _page.Locator("//input[@name='verifyAccount']");
            _amount = _page.Locator("//input[@name='amount']");
            _fromAccount = _page.Locator("//select[@name='fromAccountId']");
            _sendPaymentBtn = _page.Locator("//input[@value='Send Payment']");
        }

        public async Task GoToURL(string url)
        {
            await _page.GotoAsync(url);
        }

        public async Task AttemptPaymentWithInvalidDetails(
            string payeeName,
            string address,
            string city,
            string state,
            string zipCode,
            string phone,
            string accountNumber,
            string verifyAccount,
            string amount,
            string fromAccount)
        {
            await _payeeName.FillAsync(payeeName);
            await _address.FillAsync(address);
            await _city.FillAsync(city);
            await _state.FillAsync(state);
            await _zipCode.FillAsync(zipCode);
          //  await _phone.FillAsync(phone);
            await _accountNumber.FillAsync(accountNumber);
            await _verifyAccount.FillAsync(verifyAccount);
            await _amount.FillAsync(amount);
            await _fromAccount.SelectOptionAsync(fromAccount);
            await _sendPaymentBtn.ClickAsync();
        }

        public async Task ValidatePaymentUnsuccessful()
        {
            Assert.That(
                await _page.InnerTextAsync("//div[@class='error-message']"),
                Is.EqualTo("There was an error processing your payment. Please check your details and try again.")
            );
        }
    }
}
