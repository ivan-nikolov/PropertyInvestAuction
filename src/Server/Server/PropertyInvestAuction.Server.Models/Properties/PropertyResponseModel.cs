namespace PropertyInvestAuction.Server.Models.Properties
{
    using System.Collections.Generic;

    using PropertyInvestAuction.Server.Models.Photos;
    using PropertyInvestAuction.Services.Mapping;
    using PropertyInvestAuction.Services.Models;

    public class PropertyResponseModel : IMapFrom<PropertyDto>
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public PropertyAddressResponseModel Address { get; set; }

        public ICollection<PhotoResponseModel> Photos { get; set; } = new HashSet<PhotoResponseModel>();
    }
}
