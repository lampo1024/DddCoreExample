using System;
using DddCoreExample.Domain.Events.Country;

namespace DddCoreExample.Domain.Models.Countries
{
    public class Country : IAggregateRoot
    {
        #region Implementation of IAggregateRoot

        public Guid Id { get; protected set; }

        #endregion

        public string Name { get; protected set; }

        public static Country Create(string name)
        {
            return Create(Guid.NewGuid(), name);
        }

        public static Country Create(Guid id, string name)
        {
            var country = new Country()
            {
                Id = id,
                Name = name
            };

            DomainEvents.Raise<CountryCreated>(new CountryCreated(country));

            return country;
        }
    }
}
