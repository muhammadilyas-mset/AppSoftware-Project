using Microsoft.Playwright;
using NBomber.Contracts.Stats;
using NBomber.Contracts;
using NBomber.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NBomber.CSharp;
using System;
using System.Net;
using NUnit.Framework;

namespace AppSoftware_Project.API_Perfomance_Test
{
    
        [AllureNUnit]
        [TestFixture]

        public class APIPerfomanceTest
        {
         IPage page;
         IPlaywright playwright;

            [AllureStep]
            [Test]
            public async Task Login()
            {
                playwright = await Playwright.CreateAsync();
                var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = true,
                });

                page = await browser.NewPageAsync();
                await page.GotoAsync("https://parabank.parasoft.com/parabank/index.htm");
                await page.FillAsync("//input[@name='username']", "ilyas@gmail.com");
                await page.FillAsync("//input[@name='password']", "Parents1!");
                await page.ClickAsync("//input[@value='Log In']");
            Assert.That("Account Services", Is.EqualTo(await page.InnerTextAsync("//h2[normalize-space()='Account Services']")));

            //    await page.ClickAsync("#//a[normalize-space()='Open New Account']");
            //    await page.ClickAsync("#shopping_cart_container");
            //    await page.ClickAsync("#checkout");
            //    await page.FillAsync("#first-name", "John");
           //     await page.FillAsync("#last-name", "Smith");
           //     await page.FillAsync("#postal-code", "76400");
           //     await page.ClickAsync("#continue");
          //      Assert.AreEqual(await page.InnerTextAsync("div.page_wrapper div:nth-child(1) div.checkout_summary_container div:nth-child(1) div.summary_info > div.summary_value_label:nth-child(2)"), "SauceCard #31337");
          //      await page.ClickAsync("#finish");
          //      Assert.AreEqual(await page.InnerTextAsync("//h2[contains(text(),'Thank you for your order!')]"), "Thank you for your order!");

                await page.PauseAsync();

            }

            [Test]
            public async Task LoginPerformanceTest()
            {
                playwright = await Playwright.CreateAsync();
                var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                });

                var scenario = Scenario.Create("Load Validation", async scenarioContext =>
                {
                    var page = await browser.NewPageAsync();
                    await page.GotoAsync("https://parabank.parasoft.com/parabank/index.htm");
                    await page.FillAsync("//input[@name='username']", "ilyas@gmail.com");
                    await page.FillAsync("//input[@name='password']", "Parents1!");
                    await page.ClickAsync("//input[@value='Log In']");
                    await page.CloseAsync();
                    return Response.Ok();

                }).WithoutWarmUp().WithLoadSimulations(LoadSimulation.NewRampingConstant(50, TimeSpan.FromSeconds(60)));

                var results = NBomberRunner.RegisterScenarios(scenario)
                    .WithReportFolder("LoadRunReport")
                    .WithReportFormats(ReportFormat.Html, ReportFormat.Txt)
                    .WithWorkerPlugins(new HttpMetricsPlugin(new[] { NBomber.Http.HttpVersion.Version1 })).Run();

                Assert.True(results.ScenarioStats.Get("Load Validation").Ok.Latency.Percent99 < 4000);
            }
        }
    }
