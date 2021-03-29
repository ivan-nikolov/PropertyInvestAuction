namespace PropertyInvestAuction.Server.Models.Properties
{
    public class PropertyQueryModel : BaseQueryModel
    {
        public string Description { get; set; }

        public string CategoryId { get; set; }

        public string AddressId { get; set; }

        public string NeighborhoodId { get; set; }

        public string CityId { get; set; }

        public string CountryId { get; set; }
    }
}
