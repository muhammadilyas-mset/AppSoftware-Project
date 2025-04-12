using Microsoft.Playwright;
using SignUpAutomationExc;
using Incorrect_ForgetInfo;

namespace SignUpAutomationExc.Tests
{
    public class Incorrect_ForgetInfoTests
    {
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;

        [Test]
        public async Task Incorrect_ForgetInfo_Test()
        {
            var _playwright = await Playwright.CreateAsync();
            var _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set true for headless mode
            });

            //Open Browser
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();

            // Arrange
            var signupPage = new Incorrect_ForgetInfo_f(_page);

            // Navigate to test signup URL
            string testUrl = "https://parabank.parasoft.com/parabank/lookup.htm";
            await signupPage.GoToURL(testUrl);

            // Test Data
            string firstName = "muhammad";
            string lastName = "ilyas";
            string address = "DHA";
            string city = "Karachi";
            string state = "Sindh";
            string zipcode = "12345";
            string SSN = "4285358968";

            // Act
            await signupPage.IncorrectForgetMethod(SSN, firstName, lastName,address,state,city,zipcode); 

            // Assert
            Assert.DoesNotThrowAsync(async () => await signupPage.ValidateUnSuccessfullLogin());
        }
    


        [TearDown]
        public async Task TearDown()
        {
            // Close Browser and Clean Up
           await _context.CloseAsync();
            await _browser.CloseAsync();
        }
    }



}