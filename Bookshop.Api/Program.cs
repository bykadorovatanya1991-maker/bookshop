using Bookshop.Business.DTOs;
using Bookshop.Business.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddValidation();

builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<OrderService>();

var app = builder.Build();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseDefaultFiles();
app.UseStaticFiles();

BookshopDbContext.Seed();

var api = app.MapGroup("/api");

api.MapGet("/books", ([FromQuery] string? searchString, [FromQuery] int[]? ids, BookService bookService) =>
{
    return bookService.GetBooks(searchString, ids);
});

api.MapGet("/books/{id}", (int id, BookService bookService) =>
{
    return bookService.GetBookById(id);
});

api.MapGet("/authors", ([FromQuery] string? searchString, [FromQuery] int[]? ids, AuthorService authorService) =>
{
    return authorService.GetAuthors(searchString, ids);
});

api.MapGet("/authors/{id}", (int id, AuthorService authorService) =>
{
    return authorService.GetAuthor(id);
});

api.MapPost("/orders", (CreateOrderRequest request, OrderService orderService) =>
{
    orderService.CreateOrder(request);
});

app.Run();