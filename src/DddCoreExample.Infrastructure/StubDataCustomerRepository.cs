using System;
using System.Collections.Generic;
using DddCoreExample.Domain.Models.Countries;
using DddCoreExample.Domain.Models.Customers;
using DddCoreExample.Domain.Repository;
using DddCoreExample.Domain.Specification;

namespace DddCoreExample.Infrastructure
{
    public class StubDataCustomerRepository : IRepository<Customer>
    {
        private readonly MemoryRepository<Customer> _memRepository;

        public StubDataCustomerRepository(MemoryRepository<Customer> memRepository)
        {
            _memRepository = memRepository;
            var customer = Customer.Create(new Guid("5D5020DA-47DF-4C82-A722-C8DEAF06AE23"), "john", "smith", "john.smith@microsoft.com",
                Country.Create(new Guid("229074BD-2356-4B5A-8619-CDEBBA71CC21"), "United Kingdom"));

            customer.Add(CreditCard.Create(customer, "MR J SMITH", "123122131", DateTime.Today.AddDays(1)));

            _memRepository.Add(customer);
        }

        public Customer FindById(Guid id)
        {
            return _memRepository.FindById(id);
        }

        public Customer FindOne(ISpecification<Customer> spec)
        {
            return _memRepository.FindOne(spec);
        }

        public IEnumerable<Customer> Find(ISpecification<Customer> spec)
        {
            return _memRepository.Find(spec);
        }

        public void Add(Customer entity)
        {
            _memRepository.Add(entity);
        }

        public void Remove(Customer entity)
        {
            _memRepository.Remove(entity);
        }

        public IEnumerable<CustomerPurchaseHistoryReadModel> GetCustomersPurchaseHistory()
        {
            //Here you either call a SQL view, do HQL joins, etc.
            //This returns your read model
            throw new NotImplementedException();
        }
    }
}
