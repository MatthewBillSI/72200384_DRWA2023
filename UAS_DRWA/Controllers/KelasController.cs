using UAS_DRWA.Models;
using UAS_DRWA.Services;
using Microsoft.AspNetCore.Mvc;

namespace UAS_DRWA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KelasController : ControllerBase
{
    private readonly KelasService _kelasservice;

    public KelasController(KelasService kelasService) =>
        _kelasservice = kelasService;

    [HttpGet]
    public async Task<List<Kelas>> Get() =>
        await _kelasservice.GetAsync();

    [HttpGet("{Id:length(24)}")]
    public async Task<ActionResult<Kelas>> Get(string Id)
    {
        var kelas = await _kelasservice.GetAsync(Id);

        if (kelas is null)
        {
            return NotFound();
        }

        return kelas;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Kelas newKelas)
    {
        await _kelasservice.CreateAsync(newKelas);

        return CreatedAtAction(nameof(Get), new { Id = newKelas.Id }, newKelas);
    }

    [HttpPut("{Id:length(24)}")]
    public async Task<IActionResult> Update(string Id, Kelas UpdatedKelas)
    {
        var kelas = await _kelasservice.GetAsync(Id);

        if (kelas is null)
        {
            return NotFound();
        }

        UpdatedKelas.Id = kelas.Id;

        await _kelasservice.UpdateAsync(Id, UpdatedKelas);

        return NoContent();
    }

    [HttpDelete("{Id:length(24)}")]
    public async Task<IActionResult> Delete(string Id)
    {
        var kelas = await _kelasservice.GetAsync(Id);

        if (kelas is null)
        {
            return NotFound();
        }

        await _kelasservice.RemoveAsync(Id);

        return NoContent();
    }
}