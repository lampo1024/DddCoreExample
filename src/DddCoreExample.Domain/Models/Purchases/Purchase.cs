using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DddCoreExample.Domain.Models.Carts;

namespace DddCoreExample.Domain.Models.Purchases
{
    public class Purchase : IAggregateRoot
    {
        private List<PurchasedProduct> purchasedProducts = new List<PurchasedProduct>();
        public Guid Id { get; protected set; }
        public ReadOnlyCollection<PurchasedProduct> Products
        {
            get { return purchasedProducts.AsReadOnly(); }
        }
        public DateTime Created { get; protected set; }
        public Guid CustomerId { get; protected set; }
        public decimal TotalTax { get; protected set; }
        public decimal TotalCost { get; protected set; }

        public static Purchase Create(Cart cart)
        {
            var purchase = new Purchase()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Today,
                CustomerId = cart.CustomerId,
                TotalCost = cart.TotalCost,
                TotalTax = cart.TotalTax
            };

            var purchasedProducts = cart.Products.Select(cartProduct => PurchasedProduct.Create(purchase, cartProduct)).ToList();

            purchase.purchasedProducts = purchasedProducts;

            return purchase;
        }
    }
}
