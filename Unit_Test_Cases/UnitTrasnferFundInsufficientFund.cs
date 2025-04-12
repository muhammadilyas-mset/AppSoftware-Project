using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using AppSoftware_Project;

namespace SignUpAutomationExc.Tests
{
    public class TransferFunds_Should_CompleteSuccessfully : LoginPageTest

    { 
        [Test, Order(2)]
    public async Task TransferFunds_Should_CompleteSuccessfullyz()
        {
            // Arrange
            var transferFunds = new TransferFunds(_page);
            string testUrl = "https://parabank.parasoft.com/parabank/transfer.htm";

            // Test data
            string amount = "$00.00";
            string fromAccountId = "13788";
            string toAccountId = "137887";

            // Act
            await transferFunds.GoToURL(testUrl);
            await transferFunds.TransferFundsMethod(amount, fromAccountId, toAccountId);

            // Assert
            Assert.DoesNotThrowAsync(async () => await transferFunds.ValidateTransferSuccess());
        }

      
    }
}
