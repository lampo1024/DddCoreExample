using DddCoreExample.Domain.Models.Customers;

namespace DddCoreExample.Domain.Events.CustomerEvents
{
    public class CreditCardAdded : DomainEvent
    {
        public CreditCard CreditCard { get; private set; }

        public CreditCardAdded(CreditCard creditCard)
        {
            CreditCard = creditCard;
        }

        public override void Flatten()
        {
            this.Args.Add("CustomerId", this.CreditCard.Customer.Id);
            this.Args.Add("NameOnCard", this.CreditCard.NameOnCard);
            this.Args.Add("Last3Digits", this.CreditCard.CardNumber.Substring(this.CreditCard.CardNumber.Length - 3, 3));
        }
    }
}
