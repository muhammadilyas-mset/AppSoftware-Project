using AppSoftware_Project;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace SignUpAutomationExc.Tests
{
    public class UnitBillPaymentEmptyField : LoginPageTest
    {
        [Test, Order(2)]
        public async Task BillPayment_Should_BeSuccessful()
        {
            // Arrange
            var billPayment = new BillPaymentSuccessful(_page);

            string testUrl = "https://parabank.parasoft.com/parabank/billpay.htm";

            // Test data
            string payeeName = "";
            string address = "";
            string city = "";
            string state = "";
            string zipCode = "";
            string phone = "";
            string accountNumber = "";
            string verifyAccount = "";
            string amount = "";
            string fromAccount = ""; // Ensure this matches a valid option for "From Account"

            // Act
            await billPayment.GoToURL(testUrl);
            await billPayment.MakePayment(payeeName, address, city, state, zipCode, phone, accountNumber, verifyAccount, amount, fromAccount);

            // Assert
            Assert.DoesNotThrowAsync(async () => await billPayment.ValidatePaymentSuccessful());

            var errorMessage = await _page.InnerTextAsync("//div[contains(@class,'error')]");
            Assert.That(errorMessage, Is.EqualTo("Please fill out all fields."));
        }
    }
}
