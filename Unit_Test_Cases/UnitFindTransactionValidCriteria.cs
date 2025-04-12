using Microsoft.Playwright;
using NUnit.Framework;
using SignUpAutomationExc.Tests;
using System.Threading.Tasks;

namespace AppSoftware_Project.Tests
{
    public class UnitFindTransactionValidCriteria : LoginPageTest
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
            // Arrange
            string testUrl = "https://parabank.parasoft.com/parabank/findtrans.htm";
            string accountNumber = "13899";
            string fromDate = "12-31-2024";
            string toDate = "01-31-2025";
            string amount = "100.00";

            // Act
            await _findTransaction.GoToURL(testUrl);
            await _findTransaction.SearchTransactionsMethod(fromDate, toDate, accountNumber, amount);

            // Assert
            var transactionsTable = _page.Locator("table.dataTable");
            var rows = transactionsTable.Locator("tr");
            var transactionRows = await rows.CountAsync();

            Assert.Greater(transactionRows, 1, "No transactions found, but there should be results.");

            var successMessage = await _page.Locator("text='Transactions found'").IsVisibleAsync();
            Assert.IsTrue(successMessage, "The transactions found message did not appear.");
        }

        [Test, Order(3)]
        public async Task FindTransactions_Should_ShowError_WhenCriteriaAreInvalid()
        {
            // Arrange
            string testUrl = "https://parabank.parasoft.com/parabank/findtrans.htm";
            string invalidAccountNumber = "13899";

            // Act
            await _findTransaction.GoToURL(testUrl);
            await _findTransaction.SearchTransactionsMethod("", "", invalidAccountNumber, "");

            // Assert
            var errorMessage = await _page.Locator("text='No transactions were found for the given criteria.'").IsVisibleAsync();
            Assert.IsTrue(errorMessage, "Error message did not appear for invalid criteria.");
        }
    }
}
