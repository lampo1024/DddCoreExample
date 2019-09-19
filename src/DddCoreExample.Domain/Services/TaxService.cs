using System;
using DddCoreExample.Domain.Models.Customers;
using DddCoreExample.Domain.Models.Products;
using DddCoreExample.Domain.Models.Tax;
using DddCoreExample.Domain.Repository;
using DddCoreExample.Domain.Specification.Tax;

namespace DddCoreExample.Domain.Services
{
    public class TaxService : IDomainService
    {
        private readonly IRepository<CountryTax> _countryTax;
        private readonly Settings _settings;

        public TaxService(IRepository<CountryTax> countryTax, Settings settings)
        {
            _countryTax = countryTax;
            this._settings = settings;
        }

        public decimal Calculate(Customer customer, Product product)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (product == null)
                throw new ArgumentNullException("product");

            var customerCountryTax =
                _countryTax.FindOne(new CountryTypeOfTaxSpec(customer.CountryId, TaxType.Customer));
            var businessCountryTax =
                _countryTax.FindOne(new CountryTypeOfTaxSpec(_settings.BusinessCountry.Id, TaxType.Business));
            return (product.Cost * customerCountryTax.Percentage) + (product.Cost * businessCountryTax.Percentage);
        }
    }
}
