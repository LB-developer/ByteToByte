using ByteToByte.Models;
using ByteToByte.Services;
using Microsoft.AspNetCore.Mvc;

namespace ByteToByte.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PrintsController : Controller
{
    private readonly MongoDbService _mongoDbService;

    public PrintsController(MongoDbService mongoDbService)
    {
        _mongoDbService = mongoDbService;
    }

    [HttpGet]
    public async Task<List<ComparisonModel>> Get()
    {
        return await _mongoDbService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ComparisonModel comparisonModel)
    {
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToComparisons(string id, [FromBody] string comparisonId)
    {
        return Created();
    }
          
}
