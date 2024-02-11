using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Data.Config
{
    public class UsersGameConfig : IEntityTypeConfiguration<UsersGame>
    {
        public void Configure(EntityTypeBuilder<UsersGame> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Id); //.HasName("PK__UsersGam__3214EC075CCE7403");

            modelBuilder.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);

            modelBuilder.Property(e => e.GameId)
                .IsRequired()
                .HasMaxLength(450);

            modelBuilder.Property(e => e.Creator)
                .HasColumnType("bit");

            modelBuilder.Property(e => e.DbStatus)
                .HasColumnType("bit");

            modelBuilder.Property(e => e.DbCreatedOn)
                .HasColumnType("datetime");

            modelBuilder.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();

            //FK
            modelBuilder.HasOne(d => d.Game)
                .WithMany(p => p.UsersGames)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //.HasConstraintName("FK__UsersGame__GameI__5FB337D6");
        }
    }
}
