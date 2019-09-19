using DddCoreExample.Domain.Models.Carts;

namespace DddCoreExample.Domain.Events.CartEvents
{
    public class ProductAddedCart : DomainEvent
    {
        public CartProduct CartProduct { get; set; }

        public ProductAddedCart(CartProduct cartProduct)
        {
            CartProduct = cartProduct;
        }
        public override void Flatten()
        {
            this.Args.Add("CartId", this.CartProduct.CartId);
            this.Args.Add("CustomerId", this.CartProduct.CustomerId);
            this.Args.Add("ProductId", this.CartProduct.ProductId);
            this.Args.Add("Quantity", this.CartProduct.Quantity);
        }
    }

}
