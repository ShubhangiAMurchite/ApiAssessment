using Microsoft.EntityFrameworkCore;

namespace APIAssessment.Model
{
    public class FruitsContext : DbContext
    {
        public FruitsContext(DbContextOptions options) : base(options) { }
        public DbSet<Fruits> Fruits {get; set;}
        public DbSet<Nutritions> Nutritions { get; set; }
    }
}
