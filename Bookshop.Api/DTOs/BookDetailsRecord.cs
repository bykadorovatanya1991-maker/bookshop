namespace Bookshop.Api.DTOs
{
    public record BookDetailsRecord
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public BookDetailsRecord_Author Author { get; set; }
        public string Description { get; set; }
        public string Image { get; set; } = "";
    }

    public record BookDetailsRecord_Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
