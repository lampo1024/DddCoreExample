
namespace DddCoreExample.Domain.Events.CustomerEvents
{
    public class CustomerChangedEmail : DomainEvent
    {
        public CustomerChangedEmail(Models.Customers.Customer customer)
        {
            Customer = customer;
        }
        public Models.Customers.Customer Customer { get; private set; }

        public override void Flatten()
        {
            this.Args.Add("CustomerId", this.Customer.Id);
            this.Args.Add("Email", this.Customer.Email);
        }
    }
}
