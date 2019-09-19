using DddCoreExample.Domain.Models.Products;

namespace DddCoreExample.Domain.Events.ProductEvents
{
    public class ProductCreated : DomainEvent
    {
        public Product Product { get; set; }

        public ProductCreated(Product product)
        {
            Product = product;
        }
        public override void Flatten()
        {
            this.Args.Add("ProductId", this.Product.Id);
            this.Args.Add("ProductName", this.Product.Name);
            this.Args.Add("ProductQuantity", this.Product.Quantity);
            this.Args.Add("ProductCode", this.Product.Code.Id);
            this.Args.Add("ProductCost", this.Product.Cost);
        }
    }
}
