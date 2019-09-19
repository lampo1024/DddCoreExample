using System;
using System.Linq;
using System.Linq.Expressions;
using DddCoreExample.Domain.Models.Products;

namespace DddCoreExample.Domain.Specification.Product
{
    public class ProductReturnReasonSpec : SpecificationBase<Models.Products.Product>
    {
        readonly ReturnReason returnReason;

        public ProductReturnReasonSpec(ReturnReason returnReason)
        {
            this.returnReason = returnReason;
        }

        public override Expression<Func<Models.Products.Product, bool>> SpecExpression
        {
            get
            {
                return product => product.Returns
                    .ToList().Exists(returns => returns.Reason == this.returnReason);
            }
        }
    }
}
