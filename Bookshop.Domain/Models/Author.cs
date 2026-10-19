using System.ComponentModel.DataAnnotations;

namespace Bookshop.Domain.Models;

public class Author
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Image { get; set; } = "";

    public DateOnly DateOfBirth { get; set; }
    public DateOnly? DateOfDeath { get; set; }
    public string Biography { get; set; }

    // C# pribluda, net v DB, dlya udobstva
    // NAVIGATION PROPERTY
    public List<Book> Books { get; set; }
}