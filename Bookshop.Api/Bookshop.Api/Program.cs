

using System.Diagnostics;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();


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

app.UseCors(policy => policy.AllowAnyOrigin());

app.MapGet("/books", (string? searchString) =>
{
    if (string.IsNullOrWhiteSpace(searchString))
    {
        return books
          .Select(book =>
          {
              return new BookSearchRecord
              {
                  Id = book.Id,
                  Title = book.Title,
                  Author = book.Author,
                  Image = book.Image
              };
          })
          .ToList();
    }



    var searchedBooks = books.Where(book =>
          book.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
          book.Author.Contains(searchString, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    Console.WriteLine(searchedBooks);


    ////15.09
    //var booksByName = books.Any(book =>
    //      book.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
    //      book.Author.Contains(searchString, StringComparison.OrdinalIgnoreCase));
    //Console.Write(booksByName);

    //var sortedByPrice = books.OrderBy(book => book.Price);
    //Console.WriteLine(sortedByPrice);

    //var sortedByLanguage = books.GroupBy(g => g.Language);
    //Console.WriteLine(sortedByLanguage);

    //var knigi = books.Select(kniga => kniga.Name).ToList();






    return books
      .Where(book =>
        book.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
        book.Author.Contains(searchString, StringComparison.OrdinalIgnoreCase)
      )
      .Select(book =>
      {
          return new BookSearchRecord
          {
              Id = book.Id,
              Title = book.Title,
              Author = book.Author,
              Image = book.Image
          };
      })
      .ToList();
});



app.MapGet("/books/{id}", (int id) =>
{
    return books.Find(book => book.Id == id);
});

app.Run();

public record Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Image { get; set; } = "";

    public double Price { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public string Language { get; set; }
}

public record BookSearchRecord
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Image { get; set; } = "";
}

// dois-je mettre ici la langue? dans 116


//1) arranger les choses avec les titres de merde
//2) div avant le wrapper des livres <input>
// event handler  console log 

