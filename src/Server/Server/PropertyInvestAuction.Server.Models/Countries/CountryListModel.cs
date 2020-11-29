namespace PropertyInvestAuction.Server.Models.Countries
{
    using Services.Mapping;
    using Data.Models;

    public class CountryListModel : IMapFrom<Country>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
