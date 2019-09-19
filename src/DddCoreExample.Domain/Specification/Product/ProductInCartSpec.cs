using System;
using System.Linq.Expressions;
using DddCoreExample.Domain.Models.Carts;

namespace DddCoreExample.Domain.Specification.Product
{
    public class ProductInCartSpec : SpecificationBase<CartProduct>
    {
        readonly Models.Products.Product _product;

        public ProductInCartSpec(Models.Products.Product product)
        {
            this._product = product;
        }

        public override Expression<Func<CartProduct, bool>> SpecExpression
        {
            get
            {
                return cartProduct => cartProduct.ProductId == this._product.Id;
            }
        }
    }
}
