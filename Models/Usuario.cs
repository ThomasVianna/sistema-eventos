public class Usuario
{
    public int Id { get; set; } = 0;
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public string Tipo { get; set; } = null!;

    public List<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
}
