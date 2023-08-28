namespace PilpelKatom;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost;Database=pilpel-katom;Trusted_Connection=true;TrustServerCertificate=true");
    }

    public DbSet<SuperHero> SuperHeroes => Set<SuperHero>();
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<User> Users => Set<User>();
}