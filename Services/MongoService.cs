using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

public class MongoService
{
    private readonly IMongoDatabase _db;

    public MongoService(IConfiguration config)
    {
        var connectionString = config.GetSection("MongoSettings:ConnectionString").Value
                              ?? config.GetSection("MongoSettings")["ConnectionString"];
        var databaseName = config.GetSection("MongoSettings:DatabaseName").Value
                           ?? config.GetSection("MongoSettings")["DatabaseName"];

        var client = new MongoClient(connectionString);
        _db = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Evento> Eventos => _db.GetCollection<Evento>("Eventos");
    public IMongoCollection<Usuario> Usuarios => _db.GetCollection<Usuario>("Usuarios");
    public IMongoCollection<Inscricao> Inscricoes => _db.GetCollection<Inscricao>("Inscricoes");
}
