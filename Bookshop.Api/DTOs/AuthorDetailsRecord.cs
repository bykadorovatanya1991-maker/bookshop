namespace Bookshop.Api.DTOs
{
    public class AuthorDetailsRecord
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; } = "";
        public DateOnly DateOfBirth { get; set; }
        public DateOnly? DateOfDeath { get; set; }
        public string Biography { get; set; }
        public List<AuthorDetailsRecord_Book> Books { get; set; }

    }
    public class AuthorDetailsRecord_Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; } = "";

    }
}

