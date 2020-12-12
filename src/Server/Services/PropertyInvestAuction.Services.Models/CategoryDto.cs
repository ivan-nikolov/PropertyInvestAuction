namespace PropertyInvestAuction.Services.Models
{
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Mapping;

    public class CategoryDto : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
