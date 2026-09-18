using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext {
    public DbSet<Book> Books { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseInMemoryDatabase("MyDbContext");
    }
};
