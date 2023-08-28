namespace PilpelKatom;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public DbSet<SuperHero> SuperHeroes => Set<SuperHero>();
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<User> Users => Set<User>();
}