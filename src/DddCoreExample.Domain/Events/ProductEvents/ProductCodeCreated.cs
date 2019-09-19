using DddCoreExample.Domain.Models.Products;

namespace DddCoreExample.Domain.Events.ProductEvents
{
    public class ProductCodeCreated : DomainEvent
    {
        public ProductCode ProductCode { get; set; }

        public ProductCodeCreated(ProductCode productCode)
        {
            ProductCode = productCode;
        }
        public override void Flatten()
        {
            this.Args.Add("ProductCodeId", this.ProductCode.Id);
            this.Args.Add("ProductCodeName", this.ProductCode.Name);
        }
    }
}
