using Microsoft.EntityFrameworkCore;
using tetris_api.Models;

namespace tetris_api.Data
{
    public class ResultContext : DbContext
    {
        public ResultContext(DbContextOptions<ResultContext> options) : base(options)
        {

        }
        public DbSet<ResultModel> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var result = modelBuilder.Entity<ResultModel>();
            result.Property(x => x.name).IsRequired();
            result.Property(x => x.score).IsRequired();
            result.Property(x => x.speed).IsRequired();
        }
    }
}