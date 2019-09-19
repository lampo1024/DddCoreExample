using DddCoreExample.Domain.Models.Carts;

namespace DddCoreExample.Domain.Events.CartEvents
{
    public class CartCreated : DomainEvent
    {
        public Cart Cart { get; set; }

        public CartCreated(Cart cart)
        {
            Cart = cart;
        }
        public override void Flatten()
        {
            this.Args.Add("CustomerId", this.Cart.CustomerId);
            this.Args.Add("CartId", this.Cart.Id);
        }
    }
}
