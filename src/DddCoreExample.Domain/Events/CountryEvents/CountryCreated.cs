namespace DddCoreExample.Domain.Events.Country
{
    public class CountryCreated : DomainEvent
    {
        public Models.Countries.Country Country { get; private set; }

        public CountryCreated(Models.Countries.Country country)
        {
            Country = country;
        }

        public override void Flatten()
        {
            this.Args.Add("Id", this.Country.Id);
            this.Args.Add("Name", this.Country.Name);
        }
    }
}
