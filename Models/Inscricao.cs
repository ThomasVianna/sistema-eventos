public class Inscricao
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!; // navegação para Usuario

    public int EventoId { get; set; }
    public Evento Evento { get; set; } = null!; // navegação para Evento

    public DateTime InscritoEm { get; set; } = DateTime.Now;
}
