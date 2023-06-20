using UAS_DRWA.Models;
using UAS_DRWA.Services;
using Microsoft.AspNetCore.Mvc;

namespace UAS_DRWA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresensiharianguruController : ControllerBase
{
    private readonly PresensiGuruService _presensiGuruService;

    public PresensiharianguruController(PresensiGuruService presensiGuruService) =>
        _presensiGuruService = presensiGuruService;

    [HttpGet]
    public async Task<List<Presensiharianguru>> Get() =>
        await _presensiGuruService.GetAsync();

    [HttpGet("{Id:length(24)}")]
    public async Task<ActionResult<Presensiharianguru>> Get(string Id)
    {
        var presensiharianguru = await _presensiGuruService.GetAsync(Id);

        if (presensiharianguru is null)
        {
            return NotFound();
        }

        return presensiharianguru;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Presensiharianguru newPresensiharianguru)
    {
        await _presensiGuruService.CreateAsync(newPresensiharianguru);

        return CreatedAtAction(nameof(Get), new { Id = newPresensiharianguru.Id }, newPresensiharianguru);
    }

    [HttpPut("{Id:length(24)}")]
    public async Task<IActionResult> Update(string Id, Presensiharianguru UpdatedPresensiharianguru)
    {
        var presensiharianguru = await _presensiGuruService.GetAsync(Id);

        if (presensiharianguru is null)
        {
            return NotFound();
        }

        UpdatedPresensiharianguru.Id = presensiharianguru.Id;

        await _presensiGuruService.UpdateAsync(Id, UpdatedPresensiharianguru);

        return NoContent();
    }

    [HttpDelete("{Id:length(24)}")]
    public async Task<IActionResult> Delete(string Id)
    {
        var presensiharianguru = await _presensiGuruService.GetAsync(Id);

        if (presensiharianguru is null)
        {
            return NotFound();
        }

        await _presensiGuruService.RemoveAsync(Id);

        return NoContent();
    }
}
