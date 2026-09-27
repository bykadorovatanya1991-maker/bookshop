using System.ComponentModel.DataAnnotations;

public class Author
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }

    // C# pribluda, net v DB, dlya udobstva
    // NAVIGATION PROPERTY
    public List<Book> Books { get; set; }

}