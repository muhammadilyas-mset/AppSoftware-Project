using Microsoft.Playwright;
using SignUpAutomationExc;


namespace SignUpAutomationExc.Tests
{
    public class SignupPageTests
    {
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;

        [SetUp]
        public async Task Setup()
        {
            // Initialize Playwright and Browser
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Headless mode for CI/CD or testing
            });
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
        }

        [Test]
        public async Task SignUp_Should_CreateAccountSuccessfully()
        {
            // Arrange
            var signupPage = new SignupPage(_page);

            // Navigate to test signup URL
            string testUrl = "https://parabank.parasoft.com/parabank/register.htm";
            await signupPage.GoToURL(testUrl);

            // Test Data
            string firstName = "muhammad";
            string lastName = "ilyas";
            string address = "DHA";
            string city = "Karachi";
            string state = "Sindh";
            string zipcode = "75760";
            string mobileNumber = "123456789";
            string SSN = "4285358968";
            string username = "ilyas@gmail.comz";
            string password = "Parents1!";
            string ConfirmPassword = "Parents1!";

            // Act
            await signupPage.SignUpMethod(username, SSN, password, firstName, lastName, ConfirmPassword, address, state, city, zipcode, mobileNumber);

            // Assert
            Assert.DoesNotThrowAsync(async () => await signupPage.ValidateSuccessfullLogin());
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
