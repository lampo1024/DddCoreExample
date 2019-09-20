using System;
using System.Linq.Expressions;
using DddCoreExample.Domain.Models.Purchases;

namespace DddCoreExample.Domain.Specification.Purchases
{
    public class CustomerPurchasesSpec : SpecificationBase<Purchase>
    {
        readonly Guid _customerId;

        public CustomerPurchasesSpec(Guid customerId)
        {
            this._customerId = customerId;
        }

        public override Expression<Func<Purchase, bool>> SpecExpression
        {
            get
            {
                return purchase => purchase.CustomerId == this._customerId;
            }
        }
    }
}
