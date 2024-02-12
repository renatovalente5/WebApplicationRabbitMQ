using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationRabbitMQ.Data.Entities;

namespace WebApplicationRabbitMQ.Data.Config
{
    public class GameTypeEnumConfig : IEntityTypeConfiguration<GameTypeEnum>
    {
        public void Configure(EntityTypeBuilder<GameTypeEnum> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Id);

            modelBuilder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
