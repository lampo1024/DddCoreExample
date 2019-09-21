using System;
using System.Collections.Generic;
using DddCoreExample.Domain.Models.Products;
using DddCoreExample.Domain.Repository;
using DddCoreExample.Domain.Specification;

namespace DddCoreExample.Infrastructure
{
    public class StubDataProductRepository : IRepository<Product>
    {
        readonly MemoryRepository<Product> _memRepository;

        public StubDataProductRepository(MemoryRepository<Product> memRepository)
        {
            this._memRepository = memRepository;

            this._memRepository.Add(Product.Create(new Guid("65D03D7E-E41A-49BC-8680-DC942BABD10A"), "iPhone", 2, 500.02m,
                ProductCode.Create(new Guid("B2773EBF-CD0C-4F31-83E2-691973E32531"), "HD")));
        }

        public Product FindById(Guid id)
        {
            return this._memRepository.FindById(id);
        }

        public Product FindOne(ISpecification<Product> spec)
        {
            return this._memRepository.FindOne(spec);
        }

        public IEnumerable<Product> Find(ISpecification<Product> spec)
        {
            return this._memRepository.Find(spec);
        }

        public void Add(Product entity)
        {
            this._memRepository.Add(entity);
        }

        public void Remove(Product entity)
        {
            this._memRepository.Remove(entity);
        }
    }
}
