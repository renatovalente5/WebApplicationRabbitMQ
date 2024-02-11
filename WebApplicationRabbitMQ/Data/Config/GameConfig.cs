using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Data.Config
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Id);//.HasName("PK__Games__3214EC07F10BF0C7");

            modelBuilder.Property(e => e.Datetime)
                .HasColumnType("datetime");

            modelBuilder.Property(e => e.Duration)
                .HasColumnType("int");

            modelBuilder.Property(e => e.NumPlayers)
                .HasColumnType("int");

            modelBuilder.Property(e => e.Level)
                .IsRequired(false)
                .HasColumnType("int");

            modelBuilder.Property(e => e.Link)
                .HasMaxLength(1023);

            modelBuilder.Property(e => e.DbStatus)
                .HasColumnType("bit");

            modelBuilder.Property(e => e.DbCreatedOn)
                .HasColumnType("datetime");

            modelBuilder.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
        }
    }
}
