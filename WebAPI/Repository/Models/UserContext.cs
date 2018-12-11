using Microsoft.EntityFrameworkCore;
using Models.Cars;
using Models.Images;

namespace WebAPI.Repository.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=RoadRanger;Username=RoadRanger;Password=RoadRanger"); // should go to config
    }
}
