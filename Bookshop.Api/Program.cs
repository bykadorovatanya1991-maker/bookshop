using Bookshop.Api.DTOs;
using Bookshop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddValidation();

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

BookshopDbContext.Seed();

app.MapGet("/books", ([FromQuery] string? searchString, [FromQuery] int[]? ids) =>
{
    using (var database = new BookshopDbContext())           //new object
    {
        //if searchString is not null
        //if else ids is not null and has items
        //else ALL

        if (!string.IsNullOrWhiteSpace(searchString)) // searchString is not null or empty (searchString exists)
        {
            return database.Books                              //which books do i need 
                .Where(book => // satisfy this condition
                  book.Title.Contains(searchString) || 
                  book.Author.FirstName.Contains(searchString) ||
                  book.Author.LastName.Contains(searchString)
                )
                .Select(book => new BookSearchRecord            // from every found book make a BSR and it'll be sent to client
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author.FirstName + " " + book.Author.LastName,
                    Image = book.Image,
                    Price = book.Price
                })
                .ToList();
        }  
        else if (ids != null && ids.Length > 0) // ids collection not null and has items (there are IDs/ IDs were passed)
        {
            return database.Books
                .Where(book => ids.Contains(book.Id))
                .Select(book => new BookSearchRecord
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author.FirstName + " " + book.Author.LastName,
                    Image = book.Image,
                    Price = book.Price
                })
                .ToList();
        }

        return database.Books
            .Select(book => new BookSearchRecord
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.FirstName + " " + book.Author.LastName,
                Image = book.Image,
                Price = book.Price
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
                Description = book.Description,
                Price = book.Price
            }).First();



    }
});

app.MapGet("/authors", ([FromQuery] string? searchString, [FromQuery] int[]? ids) =>
{
    using (var database = new BookshopDbContext())         
    {
        if (!string.IsNullOrWhiteSpace(searchString))
        {
            return database.Authors                            
                .Where(author =>
                  author.FirstName.Contains(searchString) ||
                  author.LastName.Contains(searchString) 
                )
                .Select(author => new AuthorSearchRecord            // from every found author make an ASR and it'll be sent to client
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Image = author.Image,
                })
                .ToList();
        }
        else if (ids != null && ids.Length > 0)
        {
            return database.Authors
                .Where(author => ids.Contains(author.Id))
                .Select(author => new AuthorSearchRecord
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Image = author.Image,
                })
                .ToList();
        }

        return database.Authors
            .Select(author => new AuthorSearchRecord
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Image = author.Image,
            })
            .ToList();
    }
});

app.MapGet("/authors/{id}", (int id) =>
{
    using (var database = new BookshopDbContext())
    {
        return database.Authors.Where(x => x.Id == id)
             .Select(author => new AuthorDetailsRecord
             {
                 Id = author.Id,
                 FirstName = author.FirstName,
                 LastName = author.LastName,
                 DateOfBirth = author.DateOfBirth,
                 DateOfDeath = author.DateOfDeath,
                 Image = author.Image,
                 Biography = author.Biography,

                 Books = author.Books
                    .Select(book => new AuthorDetailsRecord_Book
                    {
                        Id = book.Id,
                        Image = book.Image,
                        Title = book.Title,
                        Price = book.Price
                    }).ToList(),
             }).First();
    }
});

app.MapPost("/orders", (CreateOrderRequest request) => {
    using (var database = new BookshopDbContext()) 
    {
        var order = new Order
        {
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            OrderItems = request.OrderItems.Select(item => new OrderItem
            {
                BookId = item.BookId,
                Quantity = item.Quantity
            }).ToList()
        };

        database.Orders.Add(order);

        database.SaveChanges();
    }
});

app.Run();