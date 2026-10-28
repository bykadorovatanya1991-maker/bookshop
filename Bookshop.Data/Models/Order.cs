using System.ComponentModel.DataAnnotations;

namespace Bookshop.Data.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
