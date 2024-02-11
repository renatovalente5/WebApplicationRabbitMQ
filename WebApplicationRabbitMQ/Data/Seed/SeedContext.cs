using Microsoft.EntityFrameworkCore;
using WebApplicationRabbitMQ.Data.Entities;

namespace WebApplicationRabbitMQ.Data.Seed
{
    public static class SeedContext
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.InviteEnumSeed();
        }

        private static void InviteEnumSeed(this ModelBuilder modelBuilder)
        {
            var values = new List<InviteEnum>
            {
                new InviteEnum{Id = 1, Name = "Pending"},
                new InviteEnum{Id = 2, Name = "Accepted"},
                new InviteEnum{Id = 3, Name = "Declined"}
            };
            modelBuilder.Entity<InviteEnum>().HasData(values);
        }
    }
}
