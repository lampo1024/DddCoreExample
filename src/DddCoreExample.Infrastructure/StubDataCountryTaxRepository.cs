using System;
using System.Collections.Generic;
using DddCoreExample.Domain.Models.Countries;
using DddCoreExample.Domain.Models.Tax;
using DddCoreExample.Domain.Repository;
using DddCoreExample.Domain.Specification;

namespace DddCoreExample.Infrastructure
{
    public class StubDataCountryTaxRepository : IRepository<CountryTax>
    {
        readonly MemoryRepository<CountryTax> _memRepository;

        public StubDataCountryTaxRepository(MemoryRepository<CountryTax> memRepository)
        {
            this._memRepository = memRepository;

            var countryUK = Country.Create(new Guid("229074BD-2356-4B5A-8619-CDEBBA71CC21"), "United Kingdom");
            var countryUS = Country.Create(new Guid("F3C78DD5-026F-4402-8A19-DAA956ACE593"), "United States");

            this._memRepository.Add(CountryTax.Create(new Guid("6A506865-AF49-496C-BFE1-747759B76F4A"), TaxType.Business, countryUK, 0.05m));
            this._memRepository.Add(CountryTax.Create(new Guid("D8B4C943-FCB7-4718-A56E-8B30D02992E7"), TaxType.Customer, countryUK, 0.10m));
            this._memRepository.Add(CountryTax.Create(new Guid("7F7D433B-3052-446F-99BF-A3514B7C50BA"), TaxType.Business, countryUS, 0.07m));
            this._memRepository.Add(CountryTax.Create(new Guid("1205C310-447A-48AA-A2F1-13B3E99C353E"), TaxType.Customer, countryUS, 0.15m));
        }

        public CountryTax FindById(Guid id)
        {
            return this._memRepository.FindById(id);
        }

        public CountryTax FindOne(ISpecification<CountryTax> spec)
        {
            return this._memRepository.FindOne(spec);
        }

        public IEnumerable<CountryTax> Find(ISpecification<CountryTax> spec)
        {
            return this._memRepository.Find(spec);
        }

        public void Add(CountryTax entity)
        {
            this._memRepository.Add(entity);
        }

        public void Remove(CountryTax entity)
        {
            this._memRepository.Remove(entity);
        }
    }
}
