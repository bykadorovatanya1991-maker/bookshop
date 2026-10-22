using System.ComponentModel.DataAnnotations;

namespace Bookshop.Api.DTOs;

public record CreateOrderRequest
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid email.")]
    public string Email { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    [MinLength(1, ErrorMessage = "At least one order item is required.")]
    public List<CreateOrderRequest_OrderItem> OrderItems { get; set; }

    public record CreateOrderRequest_OrderItem
    {
        [Range(1, int.MaxValue, ErrorMessage = "Invalid book.")]
        public int BookId { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
        public int Quantity { get; set; }
    }
}
