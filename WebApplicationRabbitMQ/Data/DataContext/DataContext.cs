using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplicationRabbitMQ.Data.Entities;
using WebApplicationRabbitMQ.Data.Seed;
using WebApplicationRabbitMQ.Models;

namespace WebApplicationRabbitMQ.Data.DataContext
{
    public partial class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<UsersGame> UsersGames { get; set; }
        public virtual DbSet<InviteEnum> InviteEnums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
