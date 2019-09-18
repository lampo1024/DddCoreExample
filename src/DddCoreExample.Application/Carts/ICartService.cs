using System;

namespace DddCoreExample.Application.Carts
{
    public interface ICartService
    {
        CartDto Add(Guid customerId, CartProductDto cartProductDto);
        CartDto Remove(Guid customerId, Guid productId);
        CartDto Get(Guid customerId);
        CheckOutResultDto CheckOut(Guid customerId);
    }
}
