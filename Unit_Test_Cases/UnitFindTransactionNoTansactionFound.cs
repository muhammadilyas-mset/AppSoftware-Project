using Microsoft.Playwright;
using NUnit.Framework;
using SignUpAutomationExc.Tests;
using System.Threading.Tasks;

namespace AppSoftware_Project.Tests
{
    public class UnitFindTransactionNoTansactionFound : LoginPageTest
    {


        [Test, Order(2)]
        public async Task FindTransactions_Should_ReturnResults_WhenCriteriaAreEntered()
        {

            string _testUrl = "https://parabank.parasoft.com/parabank/findtrans.htm";
            string _accountNumber = "13899";
            string _fromDate = "12/31/2024";
            string _toDate = "01/31/2025";
           
            await _page.GotoAsync(_testUrl);


            await _page.FillAsync("input[name='fromDate']", _fromDate);
            await _page.FillAsync("input[name='toDate']", _toDate);
            await _page.FillAsync("input[name='accountId']", _accountNumber);
            

            await _page.ClickAsync("input[value='Find Transactions']");

            var transactionsTable = _page.Locator("table.dataTable");
            var rows = transactionsTable.Locator("tr");
            var transactionRows = await rows.CountAsync();


            Assert.Greater(transactionRows, 1, "No transactions found, but there should be results.");



            var successMessage = await _page.Locator("text='Transactions found'").IsVisibleAsync();
            Assert.IsTrue(successMessage, "The transactions found message did not appear.");
        }

       


    }
}
