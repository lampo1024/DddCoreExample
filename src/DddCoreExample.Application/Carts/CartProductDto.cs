using System;

namespace DddCoreExample.Application.Carts
{
    public class CartProductDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
