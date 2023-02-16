using LearningResourcesApi.Adapters;
using LearningResourcesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearningResourcesApi.Controllers;

public class ResourceController : ControllerBase
{
    private readonly LearningResourcesDataContext _context;

    public ResourceController(LearningResourcesDataContext context)
    {
        _context = context;
    }

    [HttpGet("/resources")]
    public async Task<ActionResult> GetResources()
    {
        var items = await _context.Items
          .Select(item => new GetResourceItem
          {
              Id = item.Id.ToString(),
              Description = item.Description,
              Link = item.Link,
              Type = item.Type
          }).ToListAsync();
        var response = new GetResourcesResponse { Items = items };
        return Ok(response);
    }

    [HttpPost("/resources")]
    public async Task<ActionResult> AddItem([FromBody] CreateResourceItem request)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        // tomorrow - ADD IT TO THE DATABASE
        var response = new GetResourceItem
        {
            Id = Guid.NewGuid().ToString(),
            Description = request.Description,
            Link = request.Link,
            Type = request.Type,
        };
        return Ok(response);
    }
}
