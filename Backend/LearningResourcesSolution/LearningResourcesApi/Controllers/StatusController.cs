using Microsoft.AspNetCore.Mvc;

namespace LearningResourcesApi.Controllers;

public class StatusController : ControllerBase
{
    [HttpGet("/status")]
    public ActionResult GetTheStatus()
    {
        var response = new GetStatusResponse
        {
            Message = "All Good",
            Contact = "555 555-5555"
        };
        return Ok(response);
    }
}

public class GetStatusResponse 
{
    public string Message { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
}
