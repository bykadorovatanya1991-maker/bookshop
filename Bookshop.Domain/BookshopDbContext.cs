using Microsoft.EntityFrameworkCore;

public class BookshopDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseInMemoryDatabase("Bookshop");
        optionsBuilder.UseSqlServer("Server=.;Database=Bookshop;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    public static void Seed()
    {
        using (var dbContext = new BookshopDbContext())
        {
            if (dbContext.Authors.Count() == 0) {
                var authors = new List<Author> {
                    new Author {FirstName = "Goscha", LastName="Rubchinskij", DateOfBirth = new DateTime(1991, 1, 2) },
                    new Author {FirstName = "Theodor", LastName="Storm", DateOfBirth = new DateTime(1991, 1, 2) },
                    new Author {FirstName = "Ovid", LastName="", DateOfBirth = new DateTime(1991, 1, 2) },
                    new Author {FirstName = "Stefan", LastName="Zweig", DateOfBirth = new DateTime(1991, 1, 2) },
                    new Author {FirstName = "Oscar", LastName="Wilde", DateOfBirth = new DateTime(1991, 1, 2) },
                    new Author {FirstName = "Gustave", LastName="Flaubert", DateOfBirth = new DateTime(1991, 1, 2) },
                    new Author {FirstName = "Irvin D.", LastName="Yalom", DateOfBirth = new DateTime(1991, 1, 2) },
                    new Author {FirstName = "Eduard.", LastName="von Keyserling", DateOfBirth = new DateTime(1991, 1, 2) },


                };

                dbContext.Authors.AddRange(authors);

                dbContext.SaveChanges();
            }

            if (dbContext.Books.Count() == 0)
            {
                var TheodorStormAuthorId = dbContext.Authors.Where(x => x.FirstName == "Theodor" && x.LastName == "Storm").Select(x => x.Id).First();
                var EduardvonKeyserlingAuthorId = dbContext.Authors.Where(x => x.FirstName == "Eduard." && x.LastName == "von Keyserling").Select(x => x.Id).First();
                var OvidAuthorId = dbContext.Authors.Where(x => x.FirstName == "Ovid" && x.LastName == "").Select(x => x.Id).First();
                var StefanZweigAuthorId = dbContext.Authors.Where(x => x.FirstName == "Stefan" && x.LastName == "Zweig").Select(x => x.Id).First();
                var IrvinDYalomAuthorId = dbContext.Authors.Where(x => x.FirstName == "Irvin D." && x.LastName == "Yalom").Select(x => x.Id).First();
                var OscarWildeAuthorId = dbContext.Authors.Where(x => x.FirstName == "Oscar" && x.LastName == "Wilde").Select(x => x.Id).First();
                var GustaveFlaubertAuthorId = dbContext.Authors.Where(x => x.FirstName == "Gustave" && x.LastName == "Flaubert").Select(x => x.Id).First();

                var books = new List<Book>
                {
                    new Book {Title="Der Schimmelreiter", AuthorId = TheodorStormAuthorId, Image= "book images/Der Schimmelreiter.jpg", Price = 30.85M, Description= "keiurgfhi",  Language="German"},
                    new Book {Title="Wellen", AuthorId= EduardvonKeyserlingAuthorId, Image= "book images/Wellen.jpg", Price = 33, Description= "keiurgfhi", Language="German"},
                    new Book {Title="Metamorphosen", AuthorId= OvidAuthorId, Image= "book images/Metamorphosen.jpg",Price = 38.85M, Description= "keiurgfhi", Language="German" },
                    new Book {Title="Die Welt von Gestern", AuthorId= StefanZweigAuthorId, Image= "book images/Die Welt von Gestern.jpg",Price = 18.85M, Description= "keiurgfhi",  Language="German" },
                    new Book {Title="Das Bildnis des Dorian Gray", AuthorId= OscarWildeAuthorId, Image= "book images/Das Bildnis des Dorian Gray.webp",Price = 15.85M, Description= "keiurgfhi", Language="German" },
                    new Book {Title="Madame Bovary", AuthorId= GustaveFlaubertAuthorId, Image= "book images/madame bovary.webp",Price = 24, Description= "keiurgfhi", Language="French" },
                    new Book {Title="Schachnovelle", AuthorId= StefanZweigAuthorId, Image= "book images/Schachnovelle.jpg",Price = 33.85M, Description= "keiurgfhi", Language="German" },
                    new Book {Title="Und Nietzsche weinte", AuthorId= IrvinDYalomAuthorId, Image= "book images/Und Nietzsche weinte.jpg",Price = 17.85M, Description= "keiurgfhi",  Language="German"},
                    new Book {Title= "Verwirrung der Gefühle", AuthorId= StefanZweigAuthorId, Image= "book images/Verwirrung der Gefuehle.jpg",Price = 16.75M, Description= "keiurgfhi", Language="German"},
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