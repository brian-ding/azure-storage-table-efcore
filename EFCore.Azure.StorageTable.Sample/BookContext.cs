using Microsoft.EntityFrameworkCore;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseStorageTable("");
    }
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
}