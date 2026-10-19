namespace Bookshop.Api.DTOs;

public record CreateOrderRequest
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<CreateOrderRequest_OrderItem> OrderItems { get; set; }
    public record CreateOrderRequest_OrderItem
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
