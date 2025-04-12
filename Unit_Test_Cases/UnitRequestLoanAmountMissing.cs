using Microsoft.Playwright;
using NUnit.Framework;
using SignUpAutomationExc.Tests;
using System.Threading.Tasks;

namespace AppSoftware_Project.Tests
{
    public class UnitRequestLoanAmountMissing : LoginPageTest
    {

        private RequestLoan _requestLoan;

        [SetUp]
        public async Task Setup()
        {

            _requestLoan = new RequestLoan(_page);
        }

        [Test, Order(2)]
        public async Task RequestLoan_Should_ShowError_When_AmountIsMissing()
        {
           
            string testUrl = "https://parabank.parasoft.com/parabank/requestloan.htm";
            string amount = "";                    
            string downPayment = "$50.00";            
            string fromAccountId = "13788";        
            string loanType = "Personal Loan";     

            
            await _requestLoan.GoToURL(testUrl);
            await _requestLoan.FillLoanFormAsync(amount, downPayment, fromAccountId, loanType);

           
            var errorMessage = await _page.Locator("text='Please enter a valid loan amount.'").IsVisibleAsync();
            Assert.IsFalse(errorMessage, "Error message did not appear when loan amount was missing.");
            Thread.Sleep(2000);

        }




    }
}
