using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class ShoppingCart : IShoppingCart
    {
        private List<IProduct> cart;

        public ShoppingCart()
        {
            this.cart = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            this.cart.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.cart.Contains(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.cart.Remove(product);
        }

        public decimal TotalPrice()
        {
            decimal result = 0;
            foreach (IProduct product in this.cart)
            {
                result += product.Price;
            }
            return result;
        }
    }
}
