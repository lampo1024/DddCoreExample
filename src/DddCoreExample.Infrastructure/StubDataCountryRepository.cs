using System;
using System.Collections.Generic;
using DddCoreExample.Domain.Models.Countries;
using DddCoreExample.Domain.Repository;
using DddCoreExample.Domain.Specification;

namespace DddCoreExample.Infrastructure
{
    public class StubDataCountryRepository : IRepository<Country>
    {
        readonly MemoryRepository<Country> _memRepository;

        public StubDataCountryRepository(MemoryRepository<Country> memRepository)
        {
            this._memRepository = memRepository;

            memRepository.Add(Country.Create(new Guid("229074BD-2356-4B5A-8619-CDEBBA71CC21"), "United Kingdom"));
            memRepository.Add(Country.Create(new Guid("F3C78DD5-026F-4402-8A19-DAA956ACE593"), "United States"));
        }

        public Country FindById(Guid id)
        {
            return this._memRepository.FindById(id);
        }

        public Country FindOne(ISpecification<Country> spec)
        {
            return this._memRepository.FindOne(spec);
        }

        public IEnumerable<Country> Find(ISpecification<Country> spec)
        {
            return this._memRepository.Find(spec);
        }

        public void Add(Country entity)
        {
            this._memRepository.Add(entity);
        }

        public void Remove(Country entity)
        {
            this._memRepository.Remove(entity);
        }
    }
}
