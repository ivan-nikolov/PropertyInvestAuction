namespace PropertyInvestAuction.Services.Models
{
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;

    public class NeighborhoodDto : IMapFrom<Neighborhood>
    {
        public string Id { get; set; }

        public string CityId { get; set; }

        public CityDto City { get; set; }
    }
}
