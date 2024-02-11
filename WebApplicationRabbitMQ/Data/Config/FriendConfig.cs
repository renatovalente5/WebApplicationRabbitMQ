using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Data.Config
{
    public class FriendConfig : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Id);//.HasName("PK__Friends__3214EC07733B7533");

            modelBuilder.Property(e => e.DbCreatedOn)
                .HasColumnType("datetime");

            modelBuilder.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450);

            modelBuilder.Property(e => e.FriendId)
                .IsRequired()
                .HasMaxLength(450);

            modelBuilder.Property(e => e.InviteEnumId)
                .HasColumnType("int");

            modelBuilder.Property(e => e.DbStatus)
                .HasColumnType("bit");

            modelBuilder.Property(e => e.DbCreatedOn)
                .HasColumnType("datetime");

            modelBuilder.Property(e => e.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();

            //FK
            modelBuilder.HasOne(d => d.InviteEnum)
                .WithMany(p => p.Friends)
                .HasForeignKey(d => d.InviteEnumId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
