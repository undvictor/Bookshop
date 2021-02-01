using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bokbutiken.Models
{
    public class ShoppingCart
    {
        private readonly BokDbContext _bokDbContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(BokDbContext bokDbContext)
        {
            _bokDbContext = bokDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<BokDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Book book, int amount)
        {//find the item, if not in cart already add it to context increase amount and save
            var shoppingCartItem = _bokDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Book.BookId == book.BookId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Book = book,
                    Amount = 1
                };
                _bokDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _bokDbContext.SaveChanges();
        }

        public int RemoveFromCart(Book book)
        {
            var shoppingCartItem = _bokDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Book.BookId == book.BookId && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingCartItem !=null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _bokDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _bokDbContext.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {//see if the list is retrieved from the instance we have at top
            //if not we go to db and retrieve shopping cart id associated with session of user
            return ShoppingCartItems ??
                (ShoppingCartItems = _bokDbContext.ShoppingCartItems.Where(
                    c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Book)
                    .ToList() );
        }

        public void ClearCart()
        {
            var cartItems = _bokDbContext.ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);
            _bokDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _bokDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _bokDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Book.Price * c.Amount).Sum();
            return total;
        }

    }
}
