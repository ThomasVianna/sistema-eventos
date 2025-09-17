using Microsoft.EntityFrameworkCore;

public class SistemaEventosContext : DbContext
{
    public SistemaEventosContext(DbContextOptions<SistemaEventosContext> options)
        : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Inscricao> Inscricoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Inscricao>()
            .HasOne(i => i.Usuario)
            .WithMany(u => u.Inscricoes)
            .HasForeignKey(i => i.UsuarioId);

        modelBuilder.Entity<Inscricao>()
            .HasOne(i => i.Evento)
            .WithMany(e => e.Inscricoes)
            .HasForeignKey(i => i.EventoId);
    }
}
