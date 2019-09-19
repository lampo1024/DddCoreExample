using System;
using DddCoreExample.Domain.Models.Carts;

namespace DddCoreExample.Domain.Models.Purchases
{
    public class PurchasedProduct
    {
        public Guid PurchaseId { get; protected set; }
        public Guid ProductId { get; protected set; }
        public int Quantity { get; protected set; }

        public static PurchasedProduct Create(Purchase purchase, CartProduct cartProduct)
        {
            return new PurchasedProduct()
            {
                ProductId = cartProduct.ProductId,
                PurchaseId = purchase.Id,
                Quantity = cartProduct.Quantity
            };
        }
    }
}
