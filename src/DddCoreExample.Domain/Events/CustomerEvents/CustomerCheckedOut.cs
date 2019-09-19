using DddCoreExample.Domain.Models.Purchases;

namespace DddCoreExample.Domain.Events.CustomerEvents
{
    public class CustomerCheckedOut : DomainEvent
    {
        public Purchase Purchase { get; set; }

        public CustomerCheckedOut(Purchase purchase)
        {
            Purchase = purchase;
        }
        public override void Flatten()
        {
            this.Args.Add("CustomerId", this.Purchase.CustomerId);
            this.Args.Add("PurchaseId", this.Purchase.Id);
            this.Args.Add("TotalCost", this.Purchase.TotalCost);
            this.Args.Add("TotalTax", this.Purchase.TotalTax);
            this.Args.Add("NumberOfProducts", this.Purchase.Products.Count);
        }
    }
}
