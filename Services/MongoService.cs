using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

public class MongoService
{
    private readonly IMongoDatabase _db;

    public MongoService(IConfiguration config)
    {
        var client = new MongoClient(config["MongoSettings:ConnectionString"]);
        _db = client.GetDatabase(config["MongoSettings:DatabaseName"]);
    }

    public IMongoCollection<Evento> Eventos => _db.GetCollection<Evento>("Eventos");
    public IMongoCollection<Usuario> Usuarios => _db.GetCollection<Usuario>("Usuarios");
    public IMongoCollection<Inscricao> Inscricoes => _db.GetCollection<Inscricao>("Inscricoes");
}
