using KeyboardLibrary.Keycap.Domain.Entities;
using KeyboardLibrary.Keycap.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KeyboardLibrary.Keycap.API.Controllers;

[ApiController]
[Route("[controller]")]
public class KeycapsController : ControllerBase
{
    private readonly ILogger<KeycapsController> _logger;
    private readonly IKeycapService _keycapService;

    public KeycapsController(ILogger<KeycapsController> logger, IKeycapService keycapService)
    {
        _logger = logger;
        _keycapService = keycapService;
    }

    [HttpGet(Name = "GetListKeycaps")]
    public async Task<IActionResult> GetListKeycaps()
    {
      IEnumerable<KeycapEntity> keycaps = await _keycapService.GetListKeycaps();
      return Ok(keycaps);
    }

    [HttpGet("{id}", Name = "GetKeycap")]
    public async Task<IActionResult> Get(int id)
    {
      KeycapEntity keycap = await _keycapService.Get(id);
      if (keycap == null)
        return NotFound("Keycap not found");

      return Ok(keycap);
    }

    [HttpPost(Name = "CreateKeycap")]
    public async Task<IActionResult> Create(KeycapEntity keycap)
    {
      KeycapEntity newKeycap = await _keycapService.Create(keycap);
      return Ok(newKeycap);
    }

    [HttpPut(Name = "UpdateKeycap")]
    public async Task<IActionResult> Update(KeycapEntity keycap)
    {
      KeycapEntity updatedKeycap = await _keycapService.Update(keycap);
      if (updatedKeycap == null)
        return NotFound("Keycap not found");
      return Ok(updatedKeycap);
    }

    [HttpDelete("{id}", Name = "DeleteKeycap")]
    public async Task<IActionResult> Delete(int id)
    {
      bool deleted = await _keycapService.Delete(id);
      if (!deleted)
        return NotFound("Keycap not found");
      return Ok();
    }
}
