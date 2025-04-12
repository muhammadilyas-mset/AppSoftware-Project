using Microsoft.Playwright;
using NUnit.Framework;
using SignUpAutomationExc.Tests;
using System.Threading.Tasks;

namespace AppSoftware_Project.Tests
{
    public class UnitRequestLoanValidData : LoginPageTest
    {
      
        private RequestLoan _requestLoan;

        [SetUp]
        public async Task Setup()
        {
            
            _requestLoan = new RequestLoan(_page);
        }

        [Test,Order(2)]
        public async Task RequestLoan_Should_BeSuccessful_When_ValidDataIsEntered()
        {
           
            string testUrl = "https://parabank.parasoft.com/parabank/requestloan.htm";
            string amount = "$2000.00";               
            string downPayment = "$50.00";          
            string fromAccountId = "13899";      
            string loanType = "Personal Loan";    

           
            await _requestLoan.GoToURL(testUrl);
            await _requestLoan.FillLoanFormAsync(amount, downPayment, fromAccountId, loanType);

            
            await _requestLoan.ValidateLoanRequestSuccessAsync();
        }

      

        
    }
}
