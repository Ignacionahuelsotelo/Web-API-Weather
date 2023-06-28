using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using WeatherApi.Models;

namespace WeatherApi.Context
{
    public class AplicattionDbContext : DbContext
    {
        public AplicattionDbContext(DbContextOptions<AplicattionDbContext> options) : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //mapea nuestro modelo con la tabla de la db 
        public DbSet<Weather> Weather { get; set; }
        public DbSet<User> User { get; set; }

    }
}
