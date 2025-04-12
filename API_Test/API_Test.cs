using NBomber.Contracts.Stats;
using NBomber.Contracts;
using NBomber.Http;
using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using NBomber.Http.CSharp;
using NBomber.CSharp;

namespace AppSoftware_Project.API_Test
{
    public class API_Test
    {
        [SetUp]
        public async Task Setup()
        {
            var httpClient = new HttpClient();

            // Define the scenario for load testing
            var scenario = Scenario.Create("Load", async scenarioContext =>
            {
                var httpReq = Http.CreateRequest("GET", "http://localhost:3000/")
                    .WithHeader("Content-Type", "application/json")
                    .WithBody(new StringContent("{}", Encoding.UTF8, "application/json"));

                var clientResponse = await Http.Send(httpClient, httpReq);
                return clientResponse;
            })
            .WithLoadSimulations(LoadSimulation.NewInject(10, TimeSpan.FromSeconds(5), TimeSpan.FromMinutes(1)));

            // Register the scenario and generate reports
            var results = NBomberRunner.RegisterScenarios(scenario)
                .WithReportFolder("LoadRunReport")
                .WithReportFormats(ReportFormat.Html, ReportFormat.Txt)
                .WithWorkerPlugins(new HttpMetricsPlugin(new[] { HttpVersion.Version1 }))
                .Run();

            // Assert that the latency is less than 10ms for 99% of the requests
            Assert.True(results.ScenarioStats.Get("Load").Ok.Latency.Percent99 < 10);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
