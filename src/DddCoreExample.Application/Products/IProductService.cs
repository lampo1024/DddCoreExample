using System;

namespace DddCoreExample.Application.Products
{
    public interface IProductService
    {
        ProductDto Get(Guid productId);
        ProductDto Add(ProductDto product);
    }
}
