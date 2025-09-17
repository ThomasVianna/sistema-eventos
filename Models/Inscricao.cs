public class Inscricao
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public int EventoId { get; set; }
    public Evento Evento { get; set; }

    public DateTime InscritoEm { get; set; } = DateTime.Now;
}