using UAS_DRWA.Models;
using UAS_DRWA.Services;
using Microsoft.AspNetCore.Mvc;

namespace UAS_DRWA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Gurucontroller : ControllerBase
{
    private readonly GuruService _guruservice;

    public Gurucontroller(GuruService guruService) =>
        _guruservice = guruService;

    [HttpGet]
    public async Task<List<Guru>> Get() =>
        await _guruservice.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Guru>> Get(string id)
    {
        var guru = await _guruservice.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        return guru;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Guru newGuru)
    {
        await _guruservice.CreateAsync(newGuru);

        return CreatedAtAction(nameof(Get), new { id = newGuru.Id }, newGuru);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Guru updatedGuru)
    {
        var guru = await _guruservice.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        updatedGuru.Id = guru.Id;

        await _guruservice.UpdateAsync(id, updatedGuru);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var guru = await _guruservice.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        await _guruservice.RemoveAsync(id);

        return NoContent();
    }
}