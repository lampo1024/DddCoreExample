using System;
using System.Linq.Expressions;
using DddCoreExample.Domain.Models.Carts;

namespace DddCoreExample.Domain.Specification.Product
{
    public class ProductIsInStockSpec : SpecificationBase<Models.Products.Product>
    {
        readonly CartProduct productCart;

        public ProductIsInStockSpec(CartProduct productCart)
        {
            this.productCart = productCart;
        }

        public override Expression<Func<Models.Products.Product, bool>> SpecExpression
        {

            get
            {
                return product => product.Id == this.productCart.ProductId && product.Active
                                                                           && product.Quantity >= this.productCart.Quantity;
            }
        }
    }
}
