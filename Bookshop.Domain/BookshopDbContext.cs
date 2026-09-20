using Microsoft.EntityFrameworkCore;

public class BookshopDbContext : DbContext
{ // Database
    public DbSet<Book> Books { get; set; } // Table

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseInMemoryDatabase("Bookshop");
        optionsBuilder.UseSqlServer("Server=.;Database=Bookshop;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    public static void Seed()
    {
        using (var dbContext = new BookshopDbContext())
        {
            if (dbContext.Books.Count() == 0)
            {
                var books = new List<Book>
                {
                    new Book {Title="Der Schimmelreiter", Author= "Theodor Storm", Image= "book images/Der Schimmelreiter.jpg", Price = 30.85M, Description= "keiurgfhi", AuthorId = 1, Language="German"},
                    new Book {Title="Wellen", Author= "Eduard von Keyserling", Image= "book images/Wellen.jpg", Price = 33, Description= "keiurgfhi", AuthorId = 2, Language="German"},
                    new Book {Title="Metamorphosen", Author= "Ovid", Image= "book images/Metamorphosen.jpg",Price = 38.85M, Description= "keiurgfhi", AuthorId = 3, Language="German" },
                    new Book {Title="Die Welt von Gestern", Author= "Stefan Zweig", Image= "book images/Die Welt von Gestern.jpg",Price = 18.85M, Description= "keiurgfhi", AuthorId = 4, Language="German" },
                    new Book {Title="Das Bildnis des Dorian Gray", Author= "Oscar Wilde", Image= "book images/Das Bildnis des Dorian Gray.webp",Price = 15.85M, Description= "keiurgfhi", AuthorId = 5, Language="German" },
                    new Book {Title="Madame Bovary", Author= "Gustave Flaubert", Image= "book images/madame bovary.webp",Price = 24, Description= "keiurgfhi", AuthorId = 6, Language="French" },
                    new Book {Title="Schachnovelle", Author= "Stefan Zweig", Image= "book images/Schachnovelle.jpg",Price = 33.85M, Description= "keiurgfhi", AuthorId = 4, Language="German" },
                    new Book {Title="Und Nietzsche weinte", Author= "Irvin D. Yalom", Image= "book images/Und Nietzsche weinte.jpg",Price = 17.85M, Description= "keiurgfhi", AuthorId = 8, Language="German"},
                    new Book {Title= "Verwirrung der Gefühle", Author= "Stefan Zweig", Image= "book images/Verwirrung der Gefuehle.jpg",Price = 16.75M, Description= "keiurgfhi", AuthorId = 4, Language="German"},
                };

                dbContext.Books.AddRange(books);

                dbContext.SaveChanges();
            }
        }
    }
};




public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Salary { get; set; }
}

public class CleaningManager : Employee // Uborschik
{
    public List<string> RoomsToClean { get; set; }
}

public class Programmer : Employee
{
    public string ComputerName { get; set; }
}

public class Manager : Employee
{
    public List<Employee> Slaves { get; set; }
}