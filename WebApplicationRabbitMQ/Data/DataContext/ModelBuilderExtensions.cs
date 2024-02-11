using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WebApplicationRabbitMQ.Data.DataContext
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(type => type.GetInterfaces()
                    .Any(interfaceType =>
                        interfaceType.IsGenericType &&
                        interfaceType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();

            foreach (var type in types)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
