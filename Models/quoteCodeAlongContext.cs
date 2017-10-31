using Microsoft.EntityFrameworkCore;

namespace quoteCodeAlong.Models
{
    public class quoteCodeAlongContext : DbContext
    {
        public quoteCodeAlongContext(DbContextOptions<quoteCodeAlongContext> options) : base(options) {}
        public DbSet<Author> author {get; set;}
        public DbSet<Quote> quote {get; set;}
        public DbSet<categoryJoin> category_has_quote {get; set;}
        public DbSet<Category> category {get; set;}
        public DbSet<Meta> meta {get; set;}
    }
}