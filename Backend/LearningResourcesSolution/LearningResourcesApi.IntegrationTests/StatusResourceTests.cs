using LearningResourcesApi.Controllers;
using LearningResourcesApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace LearningResourcesApi.IntegrationTests;

public class StatusResourceTests
{
    [Fact]
    public async Task TheStatusResource()
    {
        await using var host = await AlbaHost.For<Program>();

        var response = await host.Scenario(api => {
            api.Get.Url("/status");
            api.StatusCodeShouldBeOk();
        });
    }

    [Fact]
    public async Task TheContactIsAPhoneNumberDuringBusinessHours()
    {
        await using var host = await AlbaHost.For<Program>(builder => 
        {
            var stubbedSystemTime = new Mock<ISystemTime>();
            stubbedSystemTime.Setup(c => c.GetCurrent()).Returns(TestData.BeforeCutoffTime);
            // var dateToReturn = new DateTimeOffset();
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ISystemTime>(stubbedSystemTime.Object);
            });
        });

        var response = await host.Scenario(api => {
            api.Get.Url("/status");
        });

        var responseMessage = response.ReadAsJson<GetStatusResponse>();
        var expectedMessage = new GetStatusResponse("All Good", "555 555-5555");
        Assert.NotNull(responseMessage);
        Assert.Equal(expectedMessage, responseMessage);
    }

    [Fact]
    public async Task TheContactIsAnEmailAfterBusinessHours()
    {
        await using var host = await AlbaHost.For<Program>(builder =>
        {
            var stubbedSystemTime = new Mock<ISystemTime>();
            stubbedSystemTime.Setup(c => c.GetCurrent()).Returns(TestData.AfterCutoffTime);
            // var dateToReturn = new DateTimeOffset();
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ISystemTime>(stubbedSystemTime.Object);
            });
        });

        var response = await host.Scenario(api => {
            api.Get.Url("/status");
        });

        var responseMessage = response.ReadAsJson<GetStatusResponse>();
        var expectedMessage = new GetStatusResponse("All Good", "bob@aol.com");
        Assert.NotNull(responseMessage);
        Assert.Equal(expectedMessage, responseMessage);
    }
}
