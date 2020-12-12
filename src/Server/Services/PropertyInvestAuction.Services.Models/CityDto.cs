namespace PropertyInvestAuction.Services.Models
{
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;

    public class CityDto : IMapFrom<City>
    {
        public string Id { get; set; }

        public string CountryId { get; set; }
    }
}
