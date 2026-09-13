

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();


var books = new List<Book>
{
  new Book {Id=1, Name="Der Schimmelreiter", Author= "Theodor Storm", Image= "book images/Der Schimmelreiter.jpg", Price = 30.85, Description= "keiurgfhi", AuthorId = 1},
  new Book {Id=2, Name="Wellen", Author= "Eduard von Keyserling", Image= "book images/Der Schimmelreiter.jpg" },
  new Book {Id=3, Name="Der Schimmelreiter", Author= "Theodor Storm", Image= "book images/Der Schimmelreiter.jpg" },
  new Book {Id=4, Name="Der Schimmelreiter", Author= "Theodor Storm", Image= "book images/Der Schimmelreiter.jpg" },
  new Book {Id=5, Name="Der Schimmelreiter", Author= "Theodor Storm", Image= "book images/Der Schimmelreiter.jpg" },
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
          Name = book.Name,
          Author = book.Author,
          Image = book.Image
        };
      })
      .ToList();
  }

  return books
    .Where(book =>
      book.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
      book.Author.Contains(searchString, StringComparison.OrdinalIgnoreCase)
    )
    .Select(book =>
    {
      return new BookSearchRecord
      {
        Id = book.Id,
        Name = book.Name,
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

public class Book
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Author { get; set; }
  public string Image { get; set; } = "";

  public double Price { get; set; }
  public string Description { get; set; }
  public int AuthorId { get; set; }

}

public class BookSearchRecord
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Author { get; set; }
  public string Image { get; set; } = "";
}

// get books po aidischke

