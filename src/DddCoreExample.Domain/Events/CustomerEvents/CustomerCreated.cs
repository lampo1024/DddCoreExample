using DddCoreExample.Domain.Models.Customers;

namespace DddCoreExample.Domain.Events.CustomerEvents
{
    public class CustomerCreated : DomainEvent
    {
        public CustomerCreated(Models.Customers.Customer customer)
        {
            Customer = customer;
        }
        public Customer Customer { get; private set; }

        public override void Flatten()
        {
            this.Args.Add("FirstName", this.Customer.FirstName);
            this.Args.Add("LastName", this.Customer.LastName);
            this.Args.Add("Email", this.Customer.Email);
            this.Args.Add("Country", this.Customer.CountryId);
        }
    }
}
