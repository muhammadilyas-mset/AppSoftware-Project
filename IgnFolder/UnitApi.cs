using Microsoft.Playwright;
using System.Reflection.PortableExecutable;
using System;


namespace unitapi
{
    public class RestAPITest
    {
        //    [SetUp]
        [Test]
        public async Task Test()
        {
            var playwright = await Playwright.CreateAsync();
            {
                var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false
                });
                var page = await browser.NewPageAsync();

                //Api url
                string apiURL = "http://localhost:3000/0";

                var response = await page.APIRequest.GetAsync(apiURL);

                if (response.Status == 200)
                {
                    Console.WriteLine("Api is now responding");
                }
                else
                {

                    Console.WriteLine($"Api Rrequest is failed now:{response.Status}");
                }

                string responseBody = await response.TextAsync();
                if (responseBody.Contains("Google Pixel 6 Pro"))
                {
                    Console.WriteLine("Body Text is Validated");
                }

                else
                {
                    Console.WriteLine("Body Text is failed!");
                }



            }
        }

        [Test]
        public async Task Post_Test()
        {
            var playwright = await Playwright.CreateAsync();
            {
                var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false
                });
                var page = await browser.NewPageAsync();

                //Api url
                string apiURL = "http://localhost:3000/posts/";

                var apiBody = new
                {
                    id = 14,
                    title = "Osamas Title",
                    views = "250"
                };

                var response = await page.APIRequest.PostAsync(apiURL, new APIRequestContextOptions
                {
                    DataObject = apiBody
                });

                if (response.Status == 201)
                {
                    Console.WriteLine("Api Body is now  posting into the file ");
                }
                else
                {
                    Console.WriteLine($"not working  {response.Status}");
                }

                string responseBody = await response.TextAsync();
                if (responseBody.Contains("Osamas Title"))
                {
                    Console.WriteLine("Body Text is Validated");
                }

                else
                {
                    Console.WriteLine("Body Text is failed!");
                }


            }

        }

        [Test]
        public async Task Delete_Post()
        {
            var playwright = await Playwright.CreateAsync();
            {
                var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false
                });
                var page = await browser.NewPageAsync();

                //Api url
                string apiURL = "http://localhost:3000/posts/2";
                var response = await page.APIRequest.DeleteAsync(apiURL);


                //Check the status of the response
                Console.WriteLine($"Response Status: {response.Status}");

                //Read and output the response body(if any)
                var responseBody = await response.BodyAsync();
                Console.WriteLine("Response Body:");
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(responseBody));

                //Close the browser
                await browser.CloseAsync();

            }
        }
    }
}