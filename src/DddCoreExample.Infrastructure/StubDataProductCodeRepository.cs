using System;
using System.Collections.Generic;
using DddCoreExample.Domain.Models.Products;
using DddCoreExample.Domain.Repository;
using DddCoreExample.Domain.Specification;

namespace DddCoreExample.Infrastructure
{
    public class StubDataProductCodeRepository : IRepository<ProductCode>
    {
        readonly MemoryRepository<ProductCode> _memRepository;

        public StubDataProductCodeRepository(MemoryRepository<ProductCode> memRepository)
        {
            this._memRepository = memRepository;

            this._memRepository.Add(ProductCode.Create(new Guid("B2773EBF-CD0C-4F31-83E2-691973E32531"), "HD"));
            this._memRepository.Add(ProductCode.Create(new Guid("A4E934EF-C40D-41B3-87DF-C65F8DDD6C23"), "VK"));
        }

        public ProductCode FindById(Guid id)
        {
            return this._memRepository.FindById(id);
        }

        public ProductCode FindOne(ISpecification<ProductCode> spec)
        {
            return this._memRepository.FindOne(spec);
        }

        public IEnumerable<ProductCode> Find(ISpecification<ProductCode> spec)
        {
            return this._memRepository.Find(spec);
        }

        public void Add(ProductCode entity)
        {
            this._memRepository.Add(entity);
        }

        public void Remove(ProductCode entity)
        {
            this._memRepository.Remove(entity);
        }
    }
}
