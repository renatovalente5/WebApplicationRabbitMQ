using Microsoft.EntityFrameworkCore;
using WebApplicationRabbitMQ.Data.Entities;

namespace WebApplicationRabbitMQ.Data.Seed
{
    public static class SeedContext
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.InviteEnumSeed();
            modelBuilder.GameTypeEnumSeed();
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

        private static void GameTypeEnumSeed(this ModelBuilder modelBuilder)
        {
            var values = new List<GameTypeEnum>
            {
                new GameTypeEnum{Id = 1, Name = "Public"},
                new GameTypeEnum{Id = 2, Name = "OnlyFriends"},
                new GameTypeEnum{Id = 3, Name = "OnlyByInvite"}
            };
            modelBuilder.Entity<GameTypeEnum>().HasData(values);
        }
    }
}
