using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]s")] // Responde em /eventos
public class EventoController : ControllerBase
{
    private readonly MongoService _mongo;

    public EventoController(MongoService mongo)
    {
        _mongo = mongo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Evento>>> Get()
    {
        var eventos = await _mongo.Eventos.Find(_ => true).ToListAsync();
        return Ok(eventos);
    }

    [HttpPost]
    public async Task<ActionResult<Evento>> Create([FromBody] Evento evento)
    {
        await _mongo.Eventos.InsertOneAsync(evento);
        return Ok(evento);
    }
}
