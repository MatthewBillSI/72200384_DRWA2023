using UAS_DRWA.Models;
using UAS_DRWA.Services;
using Microsoft.AspNetCore.Mvc;

namespace UAS_DRWA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresensimengajarController : ControllerBase
{
    private readonly PresensiMengajarService _presensiMengajarService;

    public PresensimengajarController(PresensiMengajarService presensiMengajarService) =>
        _presensiMengajarService = presensiMengajarService;

    [HttpGet]
    public async Task<List<Presensimengajar>> Get() =>
        await _presensiMengajarService.GetAsync();

    [HttpGet("{Id:length(24)}")]
    public async Task<ActionResult<Presensimengajar>> Get(string Id)
    {
        var presensimengajar = await _presensiMengajarService.GetAsync(Id);

        if (presensimengajar is null)
        {
            return NotFound();
        }

        return presensimengajar;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Presensimengajar newPresensimengajar)
    {
        await _presensiMengajarService.CreateAsync(newPresensimengajar);

        return CreatedAtAction(nameof(Get), new { Id = newPresensimengajar.Id }, newPresensimengajar);
    }

    [HttpPut("{Id:length(24)}")]
    public async Task<IActionResult> Update(string Id, Presensimengajar updatedPresensimengajar)
    {
        var presensimengajar = await _presensiMengajarService.GetAsync(Id);

        if (presensimengajar is null)
        {
            return NotFound();
        }

        updatedPresensimengajar.Id = presensimengajar.Id;

        await _presensiMengajarService.UpdateAsync(Id, updatedPresensimengajar);

        return NoContent();
    }

    [HttpDelete("{Id:length(24)}")]
    public async Task<IActionResult> Delete(string Id)
    {
        var presensimengajar = await _presensiMengajarService.GetAsync(Id);

        if (presensimengajar is null)
        {
            return NotFound();
        }

        await _presensiMengajarService.RemoveAsync(Id);

        return NoContent();
    }
}
