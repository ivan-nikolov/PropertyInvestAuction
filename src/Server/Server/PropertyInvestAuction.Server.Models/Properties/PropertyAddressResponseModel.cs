namespace PropertyInvestAuction.Server.Models.Properties
{
    using PropertyInvestAuction.Services.Mapping;
    using PropertyInvestAuction.Services.Models;

    public class PropertyAddressResponseModel : IMapFrom<AddressDto>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
