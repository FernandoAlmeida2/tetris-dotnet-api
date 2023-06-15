using Microsoft.EntityFrameworkCore;
using tetris_api.Models;

namespace tetris_api.Data
{
    public class ConnectionContext : DbContext
    {
        public DbSet<ResultModel> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
            "Server=localhost;" +
            "Port=5432; Database=tetris_dotnet_db;" +
            "User Id=postgres;" +
            "Password=ugmhe2;"
        );
    }
}