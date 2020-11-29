namespace PropertyInvestAuction.Server.Models.Country
{
    using PropertyInvestAuction.Services.Mapping;

    public class CountryListModel : IMapFrom<Data.Models.Country>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
