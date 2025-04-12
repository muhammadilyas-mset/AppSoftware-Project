using Microsoft.Playwright;
using SignUpAutomationExc;
using Incorrect_ForgetInfo;
using AppSoftware_Project;

namespace SignUpAutomationExc.Tests
{
    public class correct_ForgetInfo_f_tests
    {
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;

        [Test]
        public async Task correct_ForgetInfo_f_Test()
        {
            var _playwright = await Playwright.CreateAsync();
            var _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set true for headless mode
            });

           
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();

            
            var signupPage = new correct_ForgetInfo_f(_page);

            string testUrl = "https://parabank.parasoft.com/parabank/lookup.htm";
            await signupPage.GoToURL(testUrl);

           
            string firstName = "muhammad";
            string lastName = "ilyas";
            string address = "DHA";
            string city = "Karachi";
            string state = "Sindh";
            string zipcode = "75760";
            string SSN = "4285358968";

           
            await signupPage.correctForgetMethod(SSN, firstName, lastName,address,state,city,zipcode); 

            
            Assert.DoesNotThrowAsync(async () => await signupPage.ValidateSuccessfullLogin());
        }
    


        [TearDown]
        public async Task TearDown()
        {
            
           await _context.CloseAsync();
            await _browser.CloseAsync();
        }
    }



}