using Microsoft.Playwright;
using System.Threading.Tasks;

namespace AppSoftware_Project
{
    public class TransferFunds
    {
        private IPage _page;
        private ILocator _amount;
        private ILocator _fromAccount;
        private ILocator _toAccount;
        private ILocator _transferButton;

        public TransferFunds(IPage page)
        {
            _page = page;
            _amount = _page.Locator("//input[@id='amount']");
            _fromAccount = _page.Locator("//select[@id='fromAccountId']");
            _toAccount = _page.Locator("//select[@id='toAccountId']");
            _transferButton = _page.Locator("//input[@value='Transfer']");
        }

        public async Task GoToURL(string Url)
        {
            await _page.GotoAsync(Url);
        }

        public async Task TransferFundsMethod(string amount, string fromAccountId, string toAccountId)
        {
            await _amount.FillAsync(amount);
            await _fromAccount.SelectOptionAsync(new[] { fromAccountId });
            await _toAccount.SelectOptionAsync(new[] { toAccountId });
            await _transferButton.ClickAsync();
        }

        public async Task ValidateTransferSuccess()
        {
            Assert.That(await _page.InnerTextAsync("//h1[normalize-space()='Transfer Complete']"), Is.EqualTo("Transfer Complete!"));
        }
    }
}
