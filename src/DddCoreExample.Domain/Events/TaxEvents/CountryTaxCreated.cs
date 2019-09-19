using DddCoreExample.Domain.Models.Tax;

namespace DddCoreExample.Domain.Events.TaxEvents
{
    public class CountryTaxCreated : DomainEvent
    {
        public CountryTax CountryTax { get; set; }

        public CountryTaxCreated(CountryTax countryTax)
        {
            CountryTax = countryTax;
        }
        public override void Flatten()
        {
            this.Args.Add("CountryTaxId", CountryTax.Id);
            this.Args.Add("CountryTaxCountryId", CountryTax.Country.Id);
            this.Args.Add("CountryTaxPercentage", this.CountryTax.Percentage);
            this.Args.Add("CountryTaxType", this.CountryTax.Type);
        }
    }
}
