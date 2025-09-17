[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly SistemaEventosContext _context;

    public EventoController(SistemaEventosContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetEventos()
    {
        var eventos = await _context.Eventos.ToListAsync();
        return Ok(eventos);
    }

    [HttpPost]
    public async Task<IActionResult> CriarEvento(Evento evento)
    {
        _context.Eventos.Add(evento);
        await _context.SaveChangesAsync();
        return Ok(evento);
    }

    // Aqui você pode adicionar Put (Atualizar), Delete (Remover) etc.
}
