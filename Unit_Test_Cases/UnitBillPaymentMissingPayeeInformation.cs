using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using AppSoftware_Project;

namespace SignUpAutomationExc.Tests
{
    public class UnitBillPaymentMissingPayeeInformation : LoginPageTest
    {


        [Test, Order(2)]
        public async Task BillPayment_Should_BeSuccessful()
        {
            
            var billPayment = new BillPaymentSuccessful(_page);
            string testUrl = "https://parabank.parasoft.com/parabank/billpay.htm";

            // Test data
            string payeeName = "";
            string address = "DHA";
            string city = "Karachi";
            string state = "Sindh";
            string zipCode = "75760";
            string phone = "1234567890";
            string accountNumber = "13788";
            string verifyAccount = "13788";
            string amount = "$100.00";
            string fromAccount = "137887"; 

           
            await billPayment.GoToURL(testUrl);
            await billPayment.MakePayment(payeeName, address, city, state, zipCode, phone, accountNumber, verifyAccount, amount, fromAccount);

          
            Assert.DoesNotThrowAsync(async () => await billPayment.ValidatePaymentSuccessful());
        }
    }
}
