namespace PropertyInvestAuction.Services.Models
{
    using System.Collections.Generic;

    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;

    public class PropertyDto : IMapFrom<Property>, IMapTo<Property>
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string AddressId { get; set; }
        public AddressDto Address { get; set; }

        public string UserId { get; set; }

        public string CategoryId { get; set; }
        public CategoryDto Category { get; set; }

        public ICollection<PhotoDto> Photos { get; set; } = new HashSet<PhotoDto>();

    }
}
