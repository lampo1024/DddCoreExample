using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DddCoreExample.Domain.Events.CartEvents;
using DddCoreExample.Domain.Events.ProductEvents;
using DddCoreExample.Domain.Models.Customers;
using DddCoreExample.Domain.Models.Products;
using DddCoreExample.Domain.Specification.Product;

namespace DddCoreExample.Domain.Models.Carts
{
    public class Cart : IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        private readonly List<CartProduct> _cartProducts = new List<CartProduct>();

        public virtual ReadOnlyCollection<CartProduct> Products
        {
            get { return _cartProducts.AsReadOnly(); }
        }

        public virtual Guid CustomerId { get; protected set; }

        public virtual decimal TotalCost
        {
            get { return Products.Sum(x => x.Quantity * x.Cost); }
        }

        public virtual decimal TotalTax
        {
            get
            {
                return this.Products.Sum(x => x.Tax);
            }
        }

        public static Cart Create(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            var cart = new Cart
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id
            };
            DomainEvents.Raise(new CartCreated(cart));
            return cart;
        }

        public virtual void Add(CartProduct cartProduct)
        {
            if (cartProduct == null)
                throw new ArgumentNullException(nameof(cartProduct));
            _cartProducts.Add(cartProduct);
            DomainEvents.Raise(new ProductAddedCart(cartProduct));
        }

        public virtual void Remove(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var cartProduct =
                this._cartProducts.Find(new ProductInCartSpec(product).IsSatisfiedBy);

            DomainEvents.Raise(new ProductRemovedCart(cartProduct));

            _cartProducts.Remove(cartProduct);
        }

        public virtual void Clear()
        {
            _cartProducts.Clear();
        }
    }
}
