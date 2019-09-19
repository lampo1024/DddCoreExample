using System;
using System.Linq.Expressions;
using DddCoreExample.Domain.Models.Carts;

namespace DddCoreExample.Domain.Specification.Carts
{
    public class CustomerCartSpec : SpecificationBase<Cart>
    {
        readonly Guid _customerId;

        public CustomerCartSpec(Guid customerId)
        {
            this._customerId = customerId;
        }

        public override Expression<Func<Cart, bool>> SpecExpression
        {
            get
            {
                return cart => cart.CustomerId == this._customerId;
            }
        }
    }
}
