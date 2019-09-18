using System;

namespace DddCoreExample.Application.Carts
{
    public class CartService : ICartService
    {
        #region Implementation of ICartService

        public CartDto Add(Guid customerId, CartProductDto cartProductDto)
        {
            throw new NotImplementedException();
        }

        public CartDto Remove(Guid customerId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public CartDto Get(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public CheckOutResultDto CheckOut(Guid customerId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
