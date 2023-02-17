using LearningResourcesApi.Adapters;
using LearningResourcesApi.Domain;
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
        var response = await GetResourceItemQuery().ToListAsync();
        // var response = new GetResourcesResponse { Items = items };
        return Ok(response);
    }

    [HttpGet("/resources/{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var response = await GetResourceItemQuery()
            .Where(i => i.Id.Equals(id))
            .ToListAsync();
        return response.Count == 0 ? NotFound() : Ok(response[0]);
    }

    [HttpPost("/resources")]
    public async Task<ActionResult> AddItem([FromBody] CreateResourceItem request)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest(ModelState);
        }
        // tomorrow - ADD IT TO THE DATABASE

        var itemToSave = new LearningItem
        {
            Description = request.Description,
            Link = request.Link,
            Type = request.Type,
        };

        _context.Items.Add(itemToSave);
        await _context.SaveChangesAsync();
        var response = new GetResourceItem
        {
            Id = itemToSave.Id.ToString(),
            Description = itemToSave.Description,
            Link = itemToSave.Link,
            Type = itemToSave.Type,
        };
        return Ok(response);
    }

    private IQueryable<GetResourceItem> GetResourceItemQuery()
    {
        return _context.Items.Select(item => new GetResourceItem
        {
            Id = item.Id.ToString(),
            Description = item.Description,
            Link = item.Link,
            Type = item.Type,
        });
    }
}
