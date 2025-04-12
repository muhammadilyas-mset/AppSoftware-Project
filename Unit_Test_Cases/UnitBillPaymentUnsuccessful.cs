using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using AppSoftware_Project;

namespace SignUpAutomationExc.Tests
{
    public class BillPaymentUnsuccessfulTests : LoginPageTest
    {


        [Test, Order(2)]
        public async Task BillPayment_Should_FailWithInvalidDetails()
        {
            // Arrange
            var billPayment = new BillPaymentUnsuccessful(_page);
            string testUrl = "https://parabank.parasoft.com/parabank/billpay.htm";

           
            string payeeName = ""; 
            string address = ""; 
            string city = ""; 
            string state = ""; 
            string zipCode = ""; 
            string phone = "";
            string accountNumber = "13788"; 
            string verifyAccount = "13788"; 
            string amount = "-50"; 
            string fromAccount = ""; 

            // Act
            await billPayment.GoToURL(testUrl);
            await billPayment.AttemptPaymentWithInvalidDetails(
                payeeName,
                address,
                city,
                state,
                zipCode,
                phone,
                accountNumber,
                verifyAccount,
                amount,
                fromAccount
            );

            // Assert
            Assert.DoesNotThrowAsync(async () => await billPayment.ValidatePaymentUnsuccessful());
        }

    }
}
