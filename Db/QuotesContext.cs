using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Solution
{
    public class QuotesContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }
        public QuotesContext(DbContextOptions<QuotesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}