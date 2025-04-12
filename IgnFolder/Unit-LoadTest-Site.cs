using Microsoft.Playwright;
using NBomber.CSharp;
using NBomber.Http;
using NBomber.Http.CSharp;
using NBomber.Contracts;
using NBomber.Contracts.Stats;
using System.Text;
using static System.Net.Mime.MediaTypeNames;


namespace AppSoftware_Project;

public class LoadTests
{

    [Test]
    public async Task LoginPerformanceTest()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions

        {
            Headless = false
        });

        var scenario = Scenario.Create("Load Validation", async ScenerioContext =>
        {
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://automationexercise.com/login");
            await page.FillAsync("//input[@data-qa='login-email']", "testuserOsama@example.comz");
            await page.FillAsync("//input[@placeholder='Password']", "Password123!");
            await page.ClickAsync("//button[normalize-space()='Login']");
            await page.CloseAsync();
            return Response.Ok();
        })//inject 50 Virtual users
          // injection interval: 5 seconds", "
          //duration 1 mins (it exectures 1)
           .WithoutWarmUp()
           .WithLoadSimulations(LoadSimulation.NewRampingConstant(50, TimeSpan.FromSeconds(120)));

        var results = NBomberRunner.RegisterScenarios(scenario)
            .WithReportFolder("LoadRunReport")
            .WithReportFormats(ReportFormat.Html, ReportFormat.Txt)
            .WithWorkerPlugins(new HttpMetricsPlugin(new[] { HttpVersion.Version1 })).Run();

        Assert.True(results.ScenarioStats.Get("Load Validation").Ok.Latency.Percent99 < 2000);

    }

}