using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace SignUpAutomationExc.Tests
{
    public class TestBase
    {
        protected IBrowser _browser;
        protected IBrowserContext _context;
        protected IPage _page;

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to true for headless mode
            });
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await _context.CloseAsync();
            await _browser.CloseAsync();
        }
    }
}
