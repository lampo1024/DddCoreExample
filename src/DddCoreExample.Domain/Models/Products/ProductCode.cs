using System;
using DddCoreExample.Domain.Events.ProductEvents;

namespace DddCoreExample.Domain.Models.Products
{
    public class ProductCode : IAggregateRoot
    {
        #region Implementation of IAggregateRoot

        public Guid Id { get; protected set; }

        #endregion

        public string Name { get; protected set; }

        public static ProductCode Create(string name)
        {
            return Create(Guid.NewGuid(), name);
        }

        public static ProductCode Create(Guid id, string name)
        {
            var productCode = new ProductCode
            {
                Id = id,
                Name = name
            };

            DomainEvents.Raise(new ProductCodeCreated(productCode));

            return productCode;
        }
    }
}
