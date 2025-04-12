using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftware_Project
{
    public class OpenNewAccount
    {

        //Interfaces
         IPage _page;
        ILocator _accounttypeDropdown;
        ILocator _minimumdeposit;
         ILocator _amountInput;
        ILocator _opennewaccount_btn;

        public OpenNewAccount(IPage page)
    {
        _page = page;
            _accounttypeDropdown = _page.Locator("//select[@id='type']");
            _minimumdeposit = _page.Locator("//select[@id='fromAccountId']");
            _amountInput = _page.Locator("//input[@id='amount']");
            _opennewaccount_btn = _page.Locator("//input[@value='Open New Account']");
    }

        public async Task GoToURL(string Url)
        {
            await _page.GotoAsync(Url);
        }

        public async Task LoginAsync(string username, string password)
        {
            
            await _page.Locator("//input[@id='userName']").FillAsync(username);

             await _page.Locator("//input[@id='password']").FillAsync(password);

            await _page.Locator("//input[@value='Log In']").ClickAsync();

            await _page.WaitForSelectorAsync("//div[contains(text(),'Welcome')]");
        }
        
        public async Task OpenNewAccountAsync(string accountType, string fromAccountId, string depositAmount)
        {
            
            await _accounttypeDropdown.SelectOptionAsync(new SelectOptionValue { Label = accountType });

            
            await _minimumdeposit.SelectOptionAsync(new SelectOptionValue { Value = fromAccountId });

            
            await _amountInput.FillAsync(depositAmount);

            
            await _opennewaccount_btn.ClickAsync();

            await _page.WaitForSelectorAsync("//h1[text()='Account Opened']");

           
            var confirmationMessage = await _page.Locator("//h1[text()='Account Opened']").InnerTextAsync();
            Console.WriteLine("Confirmation: " + confirmationMessage);
        }

      
    }

}
