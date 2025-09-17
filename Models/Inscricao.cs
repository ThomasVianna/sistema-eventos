using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Inscricao
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string UsuarioId { get; set; } = null!;
    public string EventoId { get; set; } = null!;
    public DateTime InscritoEm { get; set; } = DateTime.Now;
}
