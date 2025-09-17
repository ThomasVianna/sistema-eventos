public class Evento
{
    public int Id { get; set; } = 0;
    public string Titulo { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public DateTime DataHora { get; set; }
    public string Palestrante { get; set; } = null!;
    public int Vagas { get; set; }

    public List<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
}
