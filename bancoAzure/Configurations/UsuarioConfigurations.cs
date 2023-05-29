using bancoAzure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bancoAzure.Configurations
{
    public class UsuarioConfigurations : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));
            
            builder.HasKey(x => x.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(u => u.Idade)
                .HasColumnType("int");
        }
    }
}
