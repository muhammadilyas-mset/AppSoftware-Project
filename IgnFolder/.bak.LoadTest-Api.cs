using Microsoft.Playwright;
using NBomber.CSharp;
using NBomber.Http;
using NBomber.Http.CSharp;
using NBomber.Contracts;
using NBomber.Contracts.Stats;
using System.Text;
using static System.Net.Mime.MediaTypeNames;


namespace AppSoftware_Project
{
public class Api_LoadTests
{

    [Test]
    public async Task API_PerformanceTest()
    {
        var httpClient = new HttpClient();

        // Define the scenario for load testing
        var scenario = NBomber.CSharp.Scenario.Create("Load", async scenarioContext =>
        {
            var httpReq = Http.CreateRequest("GET", "http://localhost:3000/")
                .WithHeader("Content-Type", "application/json")
                .WithBody(new StringContent("{}", Encoding.UTF8, "application/json"));

            var clientResponse = await Http.Send(httpClient, httpReq);
            return clientResponse;
        })
        .WithLoadSimulations(LoadSimulation.NewInject(10, TimeSpan.FromMilliseconds(5), TimeSpan.FromMinutes(1)));

        // Register the scenario and generate reports
        var results = NBomber.CSharp.NBomberRunner.RegisterScenarios(scenario)
            .WithReportFolder("LoadRunReport")
            .WithReportFormats(ReportFormat.Html, ReportFormat.Txt)
            .WithWorkerPlugins(new HttpMetricsPlugin(new[] { HttpVersion.Version1 }))
            .Run();

        // Assert that the latency is less than 10ms for 99% of the requests
        Assert.True(results.ScenarioStats.Get("Load").Ok.Latency.Percent99 < 10);

       // Assert that the latency is less than 10ms for 80% of the requests
      //  Assert.True(results.ScenarioStats.Get("Load").Ok.Latency.Percent80 < 10);
       // Assert that the latency is less than 10ms for 75% of the requests
        Assert.True(results.ScenarioStats.Get("Load").Ok.Latency.Percent75 < 10);


        }

    }
}