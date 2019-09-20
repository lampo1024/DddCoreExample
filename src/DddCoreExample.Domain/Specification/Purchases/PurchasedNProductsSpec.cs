using System;
using System.Linq.Expressions;
using DddCoreExample.Domain.Models.Purchases;

namespace DddCoreExample.Domain.Specification.Purchases
{
    public class PurchasedNProductsSpec : SpecificationBase<Purchase>
    {
        readonly int _nProducts;

        public PurchasedNProductsSpec(int nProducts)
        {
            this._nProducts = nProducts;
        }

        public override Expression<Func<Purchase, bool>> SpecExpression
        {
            get
            {
                return purchase => purchase.Products.Count >= this._nProducts;
            }
        }
    }
}
