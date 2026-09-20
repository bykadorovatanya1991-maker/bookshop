using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public string Image { get; set; } = "";

    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
}
