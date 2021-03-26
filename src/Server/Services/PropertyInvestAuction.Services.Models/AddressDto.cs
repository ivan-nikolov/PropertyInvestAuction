namespace PropertyInvestAuction.Services.Models
{
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;

    public class AddressDto : IMapFrom<Address>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string NeighborhoodId { get; set; }
        public NeighborhoodDto Neighborhood { get; set; }

        public string CityId { get; set; }
        public CityDto City { get; set; }
    }
}
