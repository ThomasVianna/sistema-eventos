public class Evento
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataHora { get; set; }
    public string Palestrante { get; set; }
    public int Vagas { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;

    public ICollection<Inscricao> Inscricoes { get; set; }
}