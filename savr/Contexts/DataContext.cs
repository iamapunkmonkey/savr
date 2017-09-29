using Microsoft.EntityFrameworkCore;
using savr.Models;

namespace savr.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Savr.db");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<RssItem> RssItems { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
    }
}