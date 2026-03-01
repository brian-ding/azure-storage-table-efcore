using Microsoft.EntityFrameworkCore;
using SoBrian.EntityFrameworkCore.Azure.StorageTable;

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
    [PartitionKey]
    public string Author { get; set; }
    [RowKey]
    public string Title { get; set; }
}