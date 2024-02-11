using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationRabbitMQ.Data.Entities;

namespace WebApplicationRabbitMQ.Data.Config
{
    public class InviteEnumConfig : IEntityTypeConfiguration<InviteEnum>
    {
        public void Configure(EntityTypeBuilder<InviteEnum> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Id);

            modelBuilder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
