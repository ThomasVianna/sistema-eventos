public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; } // Hash
    public string Tipo { get; set; } // "estudante" ou "admin"
    public DateTime CriadoEm { get; set; } = DateTime.Now;

    public ICollection<Inscricao> Inscricoes { get; set; }
}