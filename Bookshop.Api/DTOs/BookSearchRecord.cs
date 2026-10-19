namespace Bookshop.Api.DTOs; 

public record BookSearchRecord
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Image { get; set; } = "";
    public decimal Price { get; set; }
}
