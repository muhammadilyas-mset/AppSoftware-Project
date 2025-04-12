using Microsoft.Playwright;
using SignUpAutomationExc;
using Register_Existing;

namespace SignUpAutomationExc.Tests
{
    public class Register_Existing_EmailTests
    {
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;

        [Test]
        public async Task Register_Existing()
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
            var signupPage = new Register_Existing_Email(_page);

            // Navigate to test signup URL
            string testUrl = "https://parabank.parasoft.com/parabank/register.htm";
            await signupPage.GoToURL(testUrl);

            // Test Data
            string firstName = "Test";
            string lastName = "User";
            string address = "123 Test St";
            string city = "TestCity";
            string state = "TestState";
            string zipcode = "12345";
            string mobileNumber = "1234567890";
            string SSN = "4285358968";
            string username = "testuser_Osamaz";
            string password = "Password123!";
            string ConfirmPassword = "TestCompany";

            // Act
            await signupPage.RegisterUpMethod(username, SSN, password, firstName, lastName, ConfirmPassword, address, state, city, zipcode, mobileNumber);

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