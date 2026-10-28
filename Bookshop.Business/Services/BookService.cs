using Bookshop.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Business.Services
{
    public class BookService
    {
        public List<BookSearchRecord> GetBooks(string? searchString, int[]? ids)
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
        }

        public BookDetailsRecord GetBookById(int id)
        {
            using (var database = new BookshopDbContext())
            {
                //var books  = database.Books.Where(x => x.Id == id).ToList(); // a collection of 1 book
                //var book   = database.Books.Where(x => x.Id == id).First();  // 1 book
                //var bookId = database.Books.Where(x => x.Id == id).Select(x => x.Id).First(); // book ID
                //var bookIds = database.Books.Where(x => x.Id == id).Select(x => x.Id).ToList(); // book IDs

                // History 
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
        }
    }
}
