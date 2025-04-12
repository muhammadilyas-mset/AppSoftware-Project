using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace AppSoftware_Project.Tests
{
    public class UnitTrasnferFundInvalidAmount
    {
        private IBrowser _browser;
        private IPage _page;
        private IBrowserContext _context;
        private RequestLoan _requestLoan;

        [SetUp]
        public async Task Setup()
        {
            
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();

            
            _requestLoan = new RequestLoan(_page);
        }

       

        [Test]
        public async Task RequestLoan_Should_ShowError_When_InvalidAccountIsSelected()
        {
            
            string testUrl = "https://parabank.parasoft.com/parabank/requestloan.htm";
            string amount = "$2000.00";                
            string downPayment = "$50.00";            
            string fromAccountId = "1389987";        
            string loanType = "Personal Loan";     

            
            await _requestLoan.GoToURL(testUrl);
            await _requestLoan.FillLoanFormAsync(amount, downPayment, fromAccountId, loanType);

           
            var errorMessage = await _page.Locator("text='Account not found.'").IsVisibleAsync();
            Assert.IsTrue(errorMessage, "Error message did not appear for an invalid account ID.");
        }

       

        

        
    }
}
