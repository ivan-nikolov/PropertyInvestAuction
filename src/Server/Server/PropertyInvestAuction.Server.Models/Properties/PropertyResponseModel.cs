namespace PropertyInvestAuction.Server.Models.Properties
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;
    using PropertyInvestAuction.Services.Models;

    public class PropertyResponseModel : IMapFrom<PropertyDto>,
         IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string CategoryId { get; set; }

        public PropertyAddressResponseModel Address { get; set; }

        public ICollection<string> Photos { get; set; } = new HashSet<string>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Property, PropertyResponseModel>()
                .ForMember(pr => pr.Photos, mo => mo.MapFrom(e => e.Photos.Select(p => p.Url)));
        }
    }
}
