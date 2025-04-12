using Microsoft.Playwright;
using NUnit.Framework;
using SignUpAutomationExc.Tests;
using System.Threading.Tasks;

namespace AppSoftware_Project.Tests
{
    public class UnitFindTransactionEmptyFields : LoginPageTest
    {

        private FindTransaction _findTransaction;

        [SetUp]
        public async Task Setup()
        {
            // Initialize the Playwright page
            _findTransaction = new FindTransaction(_page);
        }

        [Test, Order(2)]
        public async Task FindTransactions_Should_ReturnResults_WhenCriteriaAreEntered()
        {

            string _testUrl = "https://parabank.parasoft.com/parabank/findtrans.htm";
            string _accountNumber = "";
            string _fromDate = "";
            string _toDate = "";
            string _amount = "";


            await _page.GotoAsync(_testUrl);
            await _findTransaction.SearchTransactionsMethod(_fromDate, _toDate, _accountNumber, _amount);


            await _page.FillAsync("input[name='fromDate']", _fromDate);
            await _page.FillAsync("input[name='toDate']", _toDate);
           // await _page.FillAsync("input[name='accountId']", _accountNumber);
            await _page.FillAsync("input[name='amount']", _amount);

            await _page.ClickAsync("input[value='Find Transactions']");

            //var transactionsTable = _page.Locator("table.dataTable");
            //var rows = transactionsTable.Locator("tr");
            //var transactionRows = await rows.CountAsync();


            //Assert.Greater(transactionRows, 1, "No transactions found, but there should be results.");



            var unsuccessMessage = await _page.Locator("//span[@id='dateRangeError']").IsVisibleAsync();
            Assert.That(await _page.InnerTextAsync("//span[@id='dateRangeError']]"), Is.EquivalentTo("Invalid date format"));
        
    }


        


    }
}
