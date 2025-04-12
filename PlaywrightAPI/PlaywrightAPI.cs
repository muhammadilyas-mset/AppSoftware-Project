using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSoftware_Project.PlaywrightAPI
{
    internal class PlaywrightAPI
    {
    
        //IPlaywright playwright;
        //IPage page;
        [Test]
        public async Task Test1()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var page = await browser.NewPageAsync();

            string apiURL = "http://localhost:3000/";
            var response = await page.APIRequest.GetAsync(apiURL);

            if (response.Status == 200)
            {
                Console.WriteLine("API is now responsing");
            }
            else
            {
                Console.WriteLine($"Failed {response.Status}");
            }

            string responseBody = await response.TextAsync();
            if (responseBody.Contains("I am ironman"))
            {
                Console.WriteLine("Validated");
            }
            else
            {
                Console.WriteLine("Body validation failed");
            }
        }

        [Test]
        public async Task Test2()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var page = await browser.NewPageAsync();

            string apiURL = "http://localhost:3000/posts";

            var apiBody = new
            {
                id = "4",
                title = "I am no one",
                views = "3000",
            };

            var response = await page.APIRequest.PostAsync(apiURL, new APIRequestContextOptions
            {
                DataObject = apiBody
            });

            if (response.Status == 201)
            {
                Console.WriteLine("API body is posting into file");
            }
            else
            {
                Console.WriteLine($"API body is posting into file failed: {response.Status}");
            }

            string responseBody = await response.TextAsync();
            if (responseBody.Contains("I am no one"))
            {
                Console.WriteLine("Post validated");
            }
            else
            {
                Console.WriteLine("Body validation failed");
            }

            await page.CloseAsync();
        }
    }
}