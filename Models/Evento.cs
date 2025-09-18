using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Evento
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public DateTime DataHora { get; set; }
    public string Palestrante { get; set; } = null!;
    public int Vagas { get; set; }

    public List<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
}
