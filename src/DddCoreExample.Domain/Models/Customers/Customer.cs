using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DddCoreExample.Domain.Events.CustomerEvents;
using DddCoreExample.Domain.Models.Countries;
using DddCoreExample.Domain.Specification.Customer;

namespace DddCoreExample.Domain.Models.Customers
{
    public class Customer : IAggregateRoot
    {
        #region Implementation of IAggregateRoot

        public Guid Id { get; protected set; }

        #endregion

        private readonly List<CreditCard> _creditCards = new List<CreditCard>();

        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual decimal Balance { get; protected set; }
        public virtual Guid CountryId { get; protected set; }

        public virtual ReadOnlyCollection<CreditCard> CreditCards { get { return this._creditCards.AsReadOnly(); } }

        public virtual void ChangeEmail(string email)
        {
            if (Email == email) return;
            Email = email;
            DomainEvents.Raise(new CustomerChangedEmail(this));
        }

        public static Customer Create(string firstname, string lastname, string email, Country country)
        {
            return Create(Guid.NewGuid(), firstname, lastname, email, country); ;
        }

        public static Customer Create(Guid id, string firstname, string lastname, string email, Country country)
        {
            if (string.IsNullOrEmpty(firstname))
                throw new ArgumentNullException("firstname");

            if (string.IsNullOrEmpty(lastname))
                throw new ArgumentNullException("lastname");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("email");

            if (country == null)
                throw new ArgumentNullException("country");

            var customer = new Customer()
            {
                Id = id,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                CountryId = country.Id
            };

            DomainEvents.Raise(new CustomerCreated(customer));

            return customer;
        }

        public virtual ReadOnlyCollection<CreditCard> GetCreditCardsAvailable()
        {
            return this._creditCards.FindAll(new CreditCardAvailableSpec(DateTime.Today).IsSatisfiedBy).AsReadOnly();
        }

        public virtual void Add(CreditCard creditCard)
        {
            this._creditCards.Add(creditCard);

            DomainEvents.Raise(new CreditCardAdded(creditCard));
        }
    }
}
