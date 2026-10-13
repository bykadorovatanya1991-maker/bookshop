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
                    new Author {FirstName = "Theodor", LastName="Storm", DateOfBirth = new DateTime(1817, 9, 14) },
                    new Author {FirstName = "Ovid", LastName="", DateOfBirth = new DateTime(1, 3, 20) }, // 20.03.43 до н.э.
                    new Author {FirstName = "Stefan", LastName="Zweig", DateOfBirth = new DateTime(1881, 11, 28) },
                    new Author {FirstName = "Oscar", LastName="Wilde", DateOfBirth = new DateTime(1854, 10, 16) },
                    new Author {FirstName = "Gustave", LastName="Flaubert", DateOfBirth = new DateTime(1821, 12, 12) },
                    new Author {FirstName = "Irvin D.", LastName="Yalom", DateOfBirth = new DateTime(1931, 6, 13) },
                    new Author {FirstName = "Eduard", LastName="von Keyserling", DateOfBirth = new DateTime(1855, 5, 14) },
                    new Author {FirstName = "George", LastName="Eliot", DateOfBirth = new DateTime(1819, 11, 22) },
                    new Author {FirstName = "Thomas", LastName="Hardy", DateOfBirth = new DateTime(1840, 6, 2) },
                    new Author {FirstName = "F. Scott", LastName="Fitzgerald", DateOfBirth = new DateTime(1896, 9, 24) },
                    new Author {FirstName = "Nikolai", LastName="Gogol", DateOfBirth = new DateTime(1809, 4, 1) },
                    new Author {FirstName = "Johann Wolfgang", LastName="von Goethe", DateOfBirth = new DateTime(1749, 8, 28) },
                    new Author {FirstName = "Theodor", LastName="Fontane", DateOfBirth = new DateTime(1819, 12, 30) },
                    new Author {FirstName = "Fjodor", LastName="Dostojewski", DateOfBirth = new DateTime(1821, 11, 11) },
                };

                dbContext.Authors.AddRange(authors);

                dbContext.SaveChanges();
            }

            if (dbContext.Books.Count() == 0)
            {
                var TheodorStormAuthorId = dbContext.Authors.Where(x => x.FirstName == "Theodor" && x.LastName == "Storm").Select(x => x.Id).First();
                var EduardvonKeyserlingAuthorId = dbContext.Authors.Where(x => x.FirstName == "Eduard" && x.LastName == "von Keyserling").Select(x => x.Id).First();
                var OvidAuthorId = dbContext.Authors.Where(x => x.FirstName == "Ovid" && x.LastName == "").Select(x => x.Id).First();
                var StefanZweigAuthorId = dbContext.Authors.Where(x => x.FirstName == "Stefan" && x.LastName == "Zweig").Select(x => x.Id).First();
                var IrvinDYalomAuthorId = dbContext.Authors.Where(x => x.FirstName == "Irvin D." && x.LastName == "Yalom").Select(x => x.Id).First();
                var OscarWildeAuthorId = dbContext.Authors.Where(x => x.FirstName == "Oscar" && x.LastName == "Wilde").Select(x => x.Id).First();
                var GustaveFlaubertAuthorId = dbContext.Authors.Where(x => x.FirstName == "Gustave" && x.LastName == "Flaubert").Select(x => x.Id).First();
                var GeorgeEliotAuthorId = dbContext.Authors.Where(x => x.FirstName == "George" && x.LastName == "Eliot").Select(x => x.Id).First();
                var ThomasHardyAuthorId = dbContext.Authors.Where(x => x.FirstName == "Thomas" && x.LastName == "Hardy").Select(x => x.Id).First();
                var FScottFitzgeraldAuthorId = dbContext.Authors.Where(x => x.FirstName == "F. Scott" && x.LastName == "Fitzgerald").Select(x => x.Id).First();
                var NikolaiGogolAuthorId = dbContext.Authors.Where(x => x.FirstName == "Nikolai" && x.LastName == "Gogol").Select(x => x.Id).First();
                var JohannWolfgangvonGoetheAuthorId = dbContext.Authors.Where(x => x.FirstName == "Johann Wolfgang" && x.LastName == "von Goethe").Select(x => x.Id).First();
                var TheodorFontaneAuthorId = dbContext.Authors.Where(x => x.FirstName == "Theodor" && x.LastName == "Fontane").Select(x => x.Id).First();
                var FjodorDostojewskiAuthorId = dbContext.Authors.Where(x => x.FirstName == "Fjodor" && x.LastName == "Dostojewski").Select(x => x.Id).First();

                var books = new List<Book>
                {
                    new Book {Title="Der Schimmelreiter", AuthorId = TheodorStormAuthorId, Image= "book images/Der Schimmelreiter.jpg", Price = 30.85M, Description= "keiurgfhi",  Language="German"},
                    new Book {Title="Wellen", AuthorId= EduardvonKeyserlingAuthorId, Image= "book images/Wellen.jpg", Price = 33, Description= "keiurgfhi", Language="German"},
                    new Book {Title="Metamorphosen", AuthorId= OvidAuthorId, Image= "book images/Metamorphosen.jpg",Price = 38.85M, Description= "Publius Ovidius Naso (43 BCE – 17/18 CE), known as Ovid, was a famous Roman poet of the Augustan age. He is best known for his mastery of Latin verse, witty style, and deep influence on Western art and literature", Language="German" },
                    new Book {Title="Die Welt von Gestern", AuthorId= StefanZweigAuthorId, Image= "book images/Die Welt von Gestern.jpg",Price = 18.85M, Description= "keiurgfhi",  Language="German" },
                    new Book {Title="Das Bildnis des Dorian Gray", AuthorId= OscarWildeAuthorId, Image= "book images/Das Bildnis des Dorian Gray.webp",Price = 15.85M, Description= "keiurgfhi", Language="German" },
                    new Book {Title="Madame Bovary", AuthorId= GustaveFlaubertAuthorId, Image= "book images/madame bovary.webp",Price = 24, Description= "keiurgfhi", Language="French" },
                    new Book {Title="Schachnovelle", AuthorId= StefanZweigAuthorId, Image= "book images/Schachnovelle.jpg",Price = 33.85M, Description= "keiurgfhi", Language="German" },
                    new Book {Title="Und Nietzsche weinte", AuthorId= IrvinDYalomAuthorId, Image= "book images/Und Nietzsche weinte.jpg",Price = 17.85M, Description= "keiurgfhi",  Language="German"},
                    new Book {Title= "Verwirrung der Gefühle", AuthorId= StefanZweigAuthorId, Image= "book images/Verwirrung der Gefuehle.jpg",Price = 16.75M, Description= "keiurgfhi", Language="German"},
                    new Book {Title="Adam Bede", AuthorId= GeorgeEliotAuthorId, Image= "book images/Adam Bede.jpg", Price = 21.85M, Description= "keiurgfhi", Language="English" },
                    new Book {Title="Clyms Heimkehr", AuthorId= ThomasHardyAuthorId, Image= "book images/Clyms Heimkehr.jpg", Price = 19.85M, Description= "keiurgfhi", Language="English" },
                    new Book {Title="Der große Gatsby", AuthorId= FScottFitzgeraldAuthorId, Image= "book images/Der Grosse Gatsby.jpg", Price = 14.85M, Description= "keiurgfhi", Language="English" },
                    new Book {Title="Die Mühle am Floss", AuthorId= GeorgeEliotAuthorId, Image= "book images/Die Muehle am Floss.jpg", Price = 22.85M, Description= "keiurgfhi", Language="English" },
                    new Book {Title="Die toten Seelen", AuthorId= NikolaiGogolAuthorId, Image= "book images/Die Toten Seelen.jpg", Price = 25.85M, Description= "keiurgfhi", Language="Russian" },
                    new Book {Title="Die Wahlverwandtschaften", AuthorId= JohannWolfgangvonGoetheAuthorId, Image= "book images/Die Wahlverwandtschaften.jpg", Price = 12.85M, Description= "keiurgfhi", Language="German" },
                    new Book {Title="Effi Briest", AuthorId= TheodorFontaneAuthorId, Image= "book images/Effi Briest.jpg", Price = 11.85M, Description= "keiurgfhi", Language="German" },
                    new Book {Title="Schuld und Sühne", AuthorId= FjodorDostojewskiAuthorId, Image= "book images/Schuld und Suehne.jpg", Price = 27.85M, Description= "keiurgfhi", Language="Russian" },
                };

                dbContext.Books.AddRange(books);

                dbContext.SaveChanges();
            }
        }
    }
};




public abstract class Employee
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