using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var books = new List<Book>
{
  new Book {Id=1, Name="Der Schimmelreiter", Author= "Theodor Storm", Image= "book images/Der Schimmelreiter.jpg" },
  new Book {Id=2, Name="Wellen", Author= "Eduard von Keyserling", Image= "book images/Der Schimmelreiter.jpg" },
  new Book {Id=3, Name="Der Schimmelreiter", Author= "Theodor Storm", Image= "book images/Der Schimmelreiter.jpg" },
  new Book {Id=4, Name="Der Schimmelreiter", Author= "Theodor Storm", Image= "book images/Der Schimmelreiter.jpg" },
  new Book {Id=5, Name="Der Schimmelreiter", Author= "Theodor Storm", Image= "book images/Der Schimmelreiter.jpg" },
};


app.MapGet("/books", (string? searchString) =>
{
  if (string.IsNullOrWhiteSpace(searchString))
  {
    return books;
  }

  return books
    .Where(book =>
      book.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
      book.Author.Contains(searchString, StringComparison.OrdinalIgnoreCase)
    )
    .ToList();
});
app.MapGet("/books/{id}", (int id) =>
{
  return books.Find(book => book.Id == id);
});

app.Run();

public class Book
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Author { get; set; }
  public string Image { get; set; } = "";

}

// get books po aidischke

