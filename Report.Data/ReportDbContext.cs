using Microsoft.EntityFrameworkCore;

namespace Report.Data
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options)
            : base(options)
        {
        }

        public ReportDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=4jm5eX4b;Host=localhost;Port=5432;Database=ReportDb;Pooling=true;Integrated Security=true;");
        }

        public DbSet<Entity.Report> Reports { get; set; }

    }
}
