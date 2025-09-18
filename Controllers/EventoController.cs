using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("eventos")]
public class EventoController : ControllerBase
{
    private readonly MongoService _mongo;

    public EventoController(MongoService mongo)
    {
        _mongo = mongo;
    }

    // GET /eventos?page=1&pageSize=10
    [HttpGet]
    public async Task<ActionResult<List<Evento>>> ListarEventos([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        if (page < 1 || pageSize < 1)
            return BadRequest(new { erro = "Parâmetros de paginação inválidos." });

        var eventos = await _mongo.Eventos
            .Find(_ => true)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        return Ok(eventos);
    }

    // POST /eventos
    [HttpPost]
    public async Task<ActionResult<Evento>> CriarEvento([FromBody] Evento evento)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _mongo.Eventos.InsertOneAsync(evento);
        return CreatedAtAction(nameof(ObterEvento), new { id = evento.Id }, evento);
    }

    // GET /eventos/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Evento>> ObterEvento(string id)
    {
        var evento = await _mongo.Eventos.Find(e => e.Id == id).FirstOrDefaultAsync();
        if (evento == null)
            return NotFound(new { erro = "Evento não encontrado." });

        return Ok(evento);
    }

    // DELETE /eventos/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarEvento(string id)
    {
        var resultado = await _mongo.Eventos.DeleteOneAsync(e => e.Id == id);
        if (resultado.DeletedCount == 0)
            return NotFound(new { erro = "Evento não encontrado." });

        return NoContent();
    }
}