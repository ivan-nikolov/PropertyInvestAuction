namespace PropertyInvestAuction.Server.Models.Neighborhoods
{
    using Data.Models;
    using Services.Mapping;

    public class NeighborhoodResponseModel : IMapFrom<Neighborhood>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
