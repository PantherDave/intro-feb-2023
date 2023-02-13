using LearningResourcesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningResourcesApi.Controllers;

public class StatusController : ControllerBase
{
    ISystemTime _systemTime;
    public StatusController(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }

    [HttpGet("/status")]
    public ActionResult GetTheStatus()
    {
        var contact = _systemTime.GetCurrent().Hour >= 16 ? "bob@aol.com" : "555 555-5555";

        var response = new GetStatusResponse("All Good", contact);
        return Ok(response);
    }
}

record class GetStatusResponse(string Message, string Contact);
//{
//    public string Message { get; set; } = string.Empty;
//    public string Contact { get; set; } = string.Empty;
//}
