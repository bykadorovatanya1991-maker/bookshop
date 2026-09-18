

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

PopulateDbBooks();

// Entity frameword (EF Core)
// Database (SQL Server)(ne pas noyer tellement) + Table
// DbContext (ala the database, but in C#) + DbSet<Book> Books (Table)


// SQL Server - DB
// Tables:
// 1. Books

// Entity frameword (EF Core)
//public class DbContext // Database
//{
//    public DbSet<Book> Books { get; set; } // Table
//    public DbSet<Author> Authors { get; set; } // Table
//}

app.UseCors(policy => policy.AllowAnyOrigin());

app.MapGet("/books", (string? searchString) =>
{
    using (var database = new MyDbContext())
    {
        if (string.IsNullOrWhiteSpace(searchString))
        {
            return database.Books
              .Select(book => new BookSearchRecord
              {
                  Id = book.Id,
                  Title = book.Title,
                  Author = book.Author,
                  Image = book.Image
              })
              .ToList();
        }

        return database.Books
          .Where(book =>
            book.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            book.Author.Contains(searchString, StringComparison.OrdinalIgnoreCase)
          )
             .Select(book => new BookSearchRecord
              {
                  Id = book.Id,
                  Title = book.Title,
                  Author = book.Author,
                  Image = book.Image
              })
             .ToList();
         }
});



app.MapGet("/books/{id}", (int id) =>
{
    using (var database = new MyDbContext())
    {
        return database.Books.Find(id);
    }
});

app.Run();

static void PopulateDbBooks()
{
    using (var dbContext = new MyDbContext())
    {
        var books = new List<Book>
      {
        new Book {Id=1, Title="Der Schimmelreiter", Author= "Theodor Storm", Image= "book images/Der Schimmelreiter.jpg", Price = 30.85, Description= "keiurgfhi", AuthorId = 1, Language="German"},
        new Book {Id=2, Title="Wellen", Author= "Eduard von Keyserling", Image= "book images/Wellen.jpg", Price = 33, Description= "keiurgfhi", AuthorId = 2, Language="German"},
        new Book {Id=3, Title="Metamorphosen", Author= "Ovid", Image= "book images/Metamorphosen.jpg",Price = 38.85, Description= "keiurgfhi", AuthorId = 3, Language="German" },
        new Book {Id=4, Title="Die Welt von Gestern", Author= "Stefan Zweig", Image= "book images/Die Welt von Gestern.jpg",Price = 18.85, Description= "keiurgfhi", AuthorId = 4, Language="German" },
        new Book {Id=5, Title="Das Bildnis des Dorian Gray", Author= "Oscar Wilde", Image= "book images/Das Bildnis des Dorian Gray.webp",Price = 15.85, Description= "keiurgfhi", AuthorId = 5, Language="German" },
        new Book {Id=6, Title="Madame Bovary", Author= "Gustave Flaubert", Image= "book images/madame bovary.webp",Price = 24, Description= "keiurgfhi", AuthorId = 6, Language="French" },
        new Book {Id=7, Title="Schachnovelle", Author= "Stefan Zweig", Image= "book images/Schachnovelle.jpg",Price = 33.85, Description= "keiurgfhi", AuthorId = 4, Language="German" },
        new Book {Id=8, Title="Und Nietzsche weinte", Author= "Irvin D. Yalom", Image= "book images/Und Nietzsche weinte.jpg",Price = 17.85, Description= "keiurgfhi", AuthorId = 8, Language="German"},
        new Book {Id=9, Title= "Verwirrung der Gefühle", Author= "Stefan Zweig", Image= "book images/Verwirrung der Gefuehle.jpg",Price = 16.75, Description= "keiurgfhi", AuthorId = 4, Language="German"},
      };

        dbContext.Books.AddRange(books);

        dbContext.SaveChanges();
    }
}

// dois-je mettre ici la langue? dans 116


//1) arranger les choses avec les titres de merde
//2) div avant le wrapper des livres <input>
// event handler  console log 


//public class Author
//{ 
//    public int AuthorId { get; set; }
//    public string Name { get; set; }
//    public string Description { get; set; }
//    public int Id { get; set; }
//    public List<Book> Books { get; set; } = new List<Book>();
//    public 
//}
