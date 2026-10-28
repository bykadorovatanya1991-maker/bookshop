using Bookshop.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Business.Services
{
    public class AuthorService
    {
        public List<AuthorSearchRecord> GetAuthors(string? searchString, int[]? ids)
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
        }

        public AuthorDetailsRecord GetAuthor(int id)
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
        }
    }
}
