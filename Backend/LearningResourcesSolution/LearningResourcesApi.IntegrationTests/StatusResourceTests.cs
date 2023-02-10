using LearningResourcesApi.Controllers;
using LearningResourcesApi.Services;

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

        var expectedContact = (new SystemTime()).GetCurrent().Hour < 16 ? "bob@aol.com" : "555 555-5555";



        var responseMessage = response.ReadAsJson<GetStatusResponse>(); 
        
        Assert.NotNull(responseMessage);
        Assert.Equal("All Good", responseMessage.Message);
        Assert.Equal("555 555-5555", responseMessage.Contact);
    }


}
