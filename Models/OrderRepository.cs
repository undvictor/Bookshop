using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bokbutiken.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BokDbContext _bokDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(BokDbContext bokDbContext, ShoppingCart shoppingCart)
        {
            _bokDbContext = bokDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {//order and orderdetails
            order.OrderPlaced = DateTime.Now;
            _bokDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    BookId = shoppingCartItem.Book.BookId,
                    //OrderId = order.OrderId,
                    Price = shoppingCartItem.Book.Price
                };
                order.OrderDetails.Add(orderDetail);  
            }
            _bokDbContext.Orders.Add(order);

            _bokDbContext.SaveChanges();
        }
    }
}
