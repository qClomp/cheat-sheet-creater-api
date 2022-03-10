
using Microsoft.AspNetCore.Mvc;
using cheat_sheat_creater_api.Models;
using cheat_sheat_creater_api.Services;

namespace cheat_sheat_creater_api.Controllers;

[ApiController]
[Route("[controller]")]
public class SheetController : ControllerBase
{
    private readonly SheetService _sheetService;

    public SheetController(SheetService inSheetService) =>
        _sheetService = inSheetService;

    [HttpGet]
    public async Task<List<Sheet>> Get() =>
        await _sheetService.GetAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Sheet>> GetText(string id)
    {
        var Sheet = await _sheetService.GetAsync(id);

        if (Sheet is null)
            return NotFound();

        return Sheet;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Sheet inSheet) 
    {
        await _sheetService.CreateAsync(inSheet);
        return CreatedAtAction(nameof(Get), new { url = inSheet.url }, inSheet);
    }

        
}