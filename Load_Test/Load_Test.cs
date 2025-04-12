using Microsoft.Playwright;
using NBomber.Contracts.Stats;
using NBomber.Contracts;
using NBomber.Http;
using NBomber.CSharp;

namespace AppSoftware_Project.Load_Test
{
    public class Load_Test
    {
    
            [SetUp]
            public async Task LoginPerfomance()
            {
                var playwright = await Playwright.CreateAsync();
                var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    //  Headless = false,
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

                Assert.True(results.ScenarioStats.Get("Load Validation").Ok.Latency.Percent99 < 6000);
            }



            [Test]
            public void Test1()
            {
                Assert.Pass();
            }
        }
    }

