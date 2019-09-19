using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DddCoreExample.Domain.Events.ProductEvents;

namespace DddCoreExample.Domain.Models.Products
{
    public class Product : IAggregateRoot
    {
        #region Implementation of IAggregateRoot

        public Guid Id { get; protected set; }

        #endregion

        private readonly List<Return> _returns = new List<Return>();
        public virtual string Name { get; protected set; }
        public virtual DateTime Created { get; protected set; }
        public virtual DateTime Modified { get; protected set; }
        public virtual bool Active { get; protected set; }
        public virtual int Quantity { get; protected set; }
        public virtual decimal Cost { get; protected set; }
        public virtual ProductCode Code { get; protected set; }
        public virtual ReadOnlyCollection<Return> Returns
        {
            get
            {
                return _returns.AsReadOnly();
            }
        }
        public static Product Create(string name, int quantity, decimal cost, ProductCode productCode)
        {
            return Create(Guid.NewGuid(), name, quantity, cost, productCode);
        }

        public static Product Create(Guid id, string name, int quantity, decimal cost, ProductCode productCode)
        {
            var product = new Product
            {
                Id = id,
                Name = name,
                Quantity = quantity,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Active = true,
                Cost = cost,
                Code = productCode
            };
            DomainEvents.Raise(new ProductCreated(product));
            return product;
        }
    }
}
