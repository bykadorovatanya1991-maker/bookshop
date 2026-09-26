using Bookshop.Api.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyOrigin());

BookshopDbContext.Seed();

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
                    Author = book.Author.FirstName + " " + book.Author.LastName,
                    Image = book.Image
                })
                .ToList();
        }

        return database.Books
            .Where(book =>
              book.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
              book.Author.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
              book.Author.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
            )
            .Select(book => new BookSearchRecord
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.FirstName + " " + book.Author.LastName,
                Image = book.Image
            })
            .ToList();
    }
});

app.MapGet("/books/{id}", (int id) =>
{
    using (var database = new BookshopDbContext())
    {
        //var books  = database.Books.Where(x => x.Id == id).ToList(); // a collection of 1 book
        //var book   = database.Books.Where(x => x.Id == id).First();  // 1 book
        //var bookId = database.Books.Where(x => x.Id == id).Select(x => x.Id).First(); // book ID
        //var bookIds = database.Books.Where(x => x.Id == id).Select(x => x.Id).ToList(); // book IDs

        // History of disease 
        // 1. EF Model (Book only)
        //return database.Books.Where(x => x.Id == id).First(); // Author = null
        // 2. EF Model (Book + Author)
        //return database.Books.Include(x => x.Author).Where(x => x.Id == id).First(); // Author = {...}
        // 3. DTO
        return database.Books.Where(x => x.Id == id)
            .Select(book => new BookDetailsRecord
                {
                    Id = book.Id,
                    Title = book.Title,
                    //AuthorId = book.AuthorId,
                    //Author = book.Author.FirstName + " " + book.Author.LastName,
                    Author = new BookDetailsRecord_Author
                    {
                        Id = book.Author.Id,
                        FirstName = book.Author.FirstName,
                        LastName = book.Author.LastName,
                    },
                    Image = book.Image,
                    Description = book.Description
                }).First();
    }
});

app.Run();