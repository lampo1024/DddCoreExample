using System;
using DddCoreExample.Domain.Events.TaxEvents;
using DddCoreExample.Domain.Models.Countries;

namespace DddCoreExample.Domain.Models.Tax
{
    public class CountryTax : IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }
        public virtual Country Country { get; protected set; }
        public virtual decimal Percentage { get; protected set; }
        public virtual TaxType Type { get; protected set; }

        public static CountryTax Create(TaxType type, Country country, decimal percentage)
        {
            return Create(Guid.NewGuid(), type, country, percentage);
        }

        public static CountryTax Create(Guid id, TaxType type, Country country, decimal percentage)
        {
            var countryTax = new CountryTax
            {
                Id = id,
                Country = country,
                Percentage = percentage,
                Type = type
            };
            DomainEvents.Raise(new CountryTaxCreated(countryTax));
            return countryTax;
        }
    }
}
