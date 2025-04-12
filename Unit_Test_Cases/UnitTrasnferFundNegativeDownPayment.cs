using Microsoft.Playwright;
using NUnit.Framework;
using SignUpAutomationExc.Tests;
using System.Threading.Tasks;

namespace AppSoftware_Project.Tests
{
    public class UnitTrasnferFundNegativeDownPayment : LoginPageTest
    {

        [Test, Order(2)]
    

        public async Task RequestLoan_Should_ShowError_When_NegativeDownPaymentIsEntered()
        {
           var requestLoan = new RequestLoan(_page); ;

        string testUrl = "https://parabank.parasoft.com/parabank/requestloan.htm";
            string amount = "$2000.00";                
            string downPayment = "-500";           
            string fromAccountId = "13788";        
            string loanType = "Personal Loan";     

            
            await requestLoan.GoToURL(testUrl);
            await requestLoan.FillLoanFormAsync(amount, downPayment, fromAccountId, loanType);


            //var errorMessage = await _page.Locator("//p[contains(text(),'An internal error has occurred and has been logged')]").IsVisibleAsync();
            //Assert.IsTrue(errorMessage, "An internal error has occurred and has been logged.");
            requestLoan.ValidateLoanRequestuNSuccessAsync();
        }

    
    }
}
