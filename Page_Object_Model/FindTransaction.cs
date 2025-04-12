using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace AppSoftware_Project
{
    public class FindTransaction
    {
        private IPage _page;
        private ILocator _fromDateInput;
        private ILocator _toDateInput;
        private ILocator _accountNumberInput;
        private ILocator _amountInput;
        private ILocator _findTransactionsBtn;
        private ILocator _transactionsTable;

        public FindTransaction(IPage page)
        {
            _page = page;
            _fromDateInput = _page.Locator("//input[@id='fromDate']");
            _toDateInput = _page.Locator("//input[@id='toDate']");
            _accountNumberInput = _page.Locator("//input[@id='accountId']");
            _amountInput = _page.Locator("//input[@id='amount']");
            _findTransactionsBtn = _page.Locator("//button[@id='findByDateRange']");
            _transactionsTable = _page.Locator("//table[@class='dataTable']");
        }

        public async Task GoToURL(string url)
        {
            await _page.GotoAsync(url);
        }

        public async Task SearchTransactionsMethod(
            string fromDate,
            string toDate,
            string accountNumber,
            string amount)
        {
            // Fill the fields only if the input is not null or empty
            await _fromDateInput.FillAsync(fromDate);
            await _toDateInput.FillAsync(toDate);
         //   await _accountNumberInput.FillAsync(accountNumber);
            await _amountInput.FillAsync(amount);

            // Click the Find Transactions button
            await _findTransactionsBtn.ClickAsync();

            // Wait for the results table to load
        //    await _page.WaitForSelectorAsync("//table[@class='dataTable']");

            // Validate if transactions are found
            //var rows = await _transactionsTable.Locator("tr").CountAsync();
            //if (rows > 1)
            //{
            //    Console.WriteLine("Transactions found.");
            //}
            //else
            //{
            //    Console.WriteLine("No transactions found.");
            //}
        }

        public async Task ValidateErrorMessageAsync()
        {
            var errorMessage = await _page.Locator("text='No transactions were found for the given criteria.'").IsVisibleAsync();
            if (errorMessage)
            {
                Console.WriteLine("Error: No transactions found for the given criteria.");
            }
            else
            {
                Console.WriteLine("Transactions found.");
            }
        }

        public async Task ValidateSuccessMessageAsync()
        {
            var successMessage = await _page.Locator("text='Transactions found'").IsVisibleAsync();
            if (successMessage)
            {
                Console.WriteLine("Success: Transactions found.");
            }
            else
            {
                Console.WriteLine("No transactions found.");
            }
        }
    }
}
