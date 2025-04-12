using Microsoft.Playwright;
using System.Threading.Tasks;

namespace AppSoftware_Project
{
    public class RequestLoan
    {
        
        private IPage _page;
        private ILocator _amountField;
        private ILocator _downPaymentField;
        private ILocator _fromAccountDropdown;
        private ILocator _loanTypeDropdown;
        private ILocator _applyButton;

        
        public RequestLoan(IPage page)
        {
            _page = page;
            _amountField = _page.Locator("//input[@id='amount']");
            _downPaymentField = _page.Locator("//input[@id='downPayment']");
            _fromAccountDropdown = _page.Locator("//select[@id='fromAccountId']");
            _loanTypeDropdown = _page.Locator("//select[@id='loanType']");
            _applyButton = _page.Locator("//input[@value='Apply Now']");
        }

       
        public async Task GoToURL(string url)
        {
            await _page.GotoAsync(url);
        }

        
        public async Task FillLoanFormAsync(string amount, string downPayment, string fromAccountId, string loanType)
        {
            await _amountField.FillAsync(amount);
            await _downPaymentField.FillAsync(downPayment); 
           // await _fromAccountDropdown.SelectOptionAsync(new SelectOptionValue { Value = fromAccountId }); 
         //   await _loanTypeDropdown.SelectOptionAsync(new SelectOptionValue { Label = loanType }); 
            await _applyButton.ClickAsync(); 
        }

        
        public async Task ValidateLoanRequestSuccessAsync()
        {
            
            var successMessage = await _page.Locator("text='Loan Request Successful'").IsVisibleAsync();
            if (!successMessage)
            {
                throw new Exception("An internal error has occurred and has been logged.");
            }
        }
        public async Task ValidateLoanRequestuNSuccessAsync() {
            Assert.That(await _page.InnerTextAsync("//p[contains(text(),'An internal error has occurred and has been logged')]"), Is.EquivalentTo("An internal error has occurred and has been logged."));

        }

    }
}
