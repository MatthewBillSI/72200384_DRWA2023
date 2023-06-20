using UAS_DRWA.Models;
using UAS_DRWA.Services;
using Microsoft.AspNetCore.Mvc;

namespace UAS_DRWA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MapelController : ControllerBase

{
    private readonly MapelService _mapelservice;

public MapelController(MapelService mapelService) =>
    _mapelservice = mapelService;

[HttpGet]
public async Task<List<Mapel>> Get() =>
    await _mapelservice.GetAsync();

[HttpGet("{Id:length(24)}")]
public async Task<ActionResult<Mapel>> Get(string Id)
{
    var mapel = await _mapelservice.GetAsync(Id);

    if (mapel is null)
    {
        return NotFound();
    }

    return mapel;
}

[HttpPost]
public async Task<IActionResult> Post(Mapel newMapel)
{
    await _mapelservice.CreateAsync(newMapel);

    return CreatedAtAction(nameof(Get), new { Id = newMapel.Id }, newMapel);
}

[HttpPut("{Id:length(24)}")]
public async Task<IActionResult> Update(string Id, Mapel UpdatedMapel)
{
    var mapel = await _mapelservice.GetAsync(Id);

    if (mapel is null)
    {
        return NotFound();
    }

    UpdatedMapel.Id = mapel.Id;

    await _mapelservice.UpdateAsync(Id, UpdatedMapel);

    return NoContent();
}

[HttpDelete("{Id:length(24)}")]
public async Task<IActionResult> Delete(string Id)
{
    var mapel = await _mapelservice.GetAsync(Id);

    if (mapel is null)
    {
        return NotFound();
    }

    await _mapelservice.RemoveAsync(Id);

    return NoContent();
}
}