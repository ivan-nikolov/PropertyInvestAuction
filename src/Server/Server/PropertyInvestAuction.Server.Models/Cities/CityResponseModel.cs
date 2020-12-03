namespace PropertyInvestAuction.Server.Models.Cities
{
    using Data.Models;
    using Services.Mapping;

    public class CityResponseModel : IMapFrom<City>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CountryId { get; set; }
    }
}
