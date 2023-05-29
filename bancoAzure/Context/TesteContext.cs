using bancoAzure.Configurations;
using bancoAzure.Models;
using Microsoft.EntityFrameworkCore;

namespace bancoAzure.Context;

public class TesteContext : DbContext
{
    public TesteContext(DbContextOptions<TesteContext> options) : base(options)  {}

    public DbSet<Usuario> usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UsuarioConfigurations());
    }

}
