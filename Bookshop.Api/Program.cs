var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyOrigin());

app.MapGet("/books", (string? searchString) =>
{
    using (var database = new BookshopDbContext())
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
    using (var database = new BookshopDbContext())
    {
        return database.Books.Find(id);
    }
});

app.Run();