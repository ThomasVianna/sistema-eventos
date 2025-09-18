using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Evento
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [Required, MinLength(3)]
    public string Titulo { get; set; } = null!;

    [Required, MinLength(10)]
    public string Descricao { get; set; } = null!;

    [Required]
    public DateTime DataHora { get; set; }

    [Required, MinLength(3)]
    public string Palestrante { get; set; } = null!;

    [Range(1, int.MaxValue)]
    public int Vagas { get; set; }

    public List<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
}
