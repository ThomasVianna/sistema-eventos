using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EventoService
{
    private readonly IMongoCollection<Evento> _collection;

    public EventoService(IMongoDatabase database)
    {
        _collection = database.GetCollection<Evento>("Eventos");
    }

    public async Task<List<Evento>> BuscarPaginado(int page, int pageSize)
    {
        return await _collection.Find(_ => true)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
    }
}