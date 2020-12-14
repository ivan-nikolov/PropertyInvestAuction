namespace PropertyInvestAuction.Server.Models.Addresses
{
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;

    public class AddressResponseModel : IMapFrom<Address>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
