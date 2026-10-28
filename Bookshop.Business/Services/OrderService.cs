using Azure.Core;
using Bookshop.Business.DTOs;
using Bookshop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Business.Services
{
    public class OrderService
    {
        public void CreateOrder(CreateOrderRequest request)
        {
            using (var database = new BookshopDbContext())
            {
                var order = new Order
                {
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    OrderItems = request.OrderItems.Select(item => new OrderItem
                    {
                        BookId = item.BookId,
                        Quantity = item.Quantity
                    }).ToList()
                };

                database.Orders.Add(order);

                database.SaveChanges();
            }
        }
    }
}
