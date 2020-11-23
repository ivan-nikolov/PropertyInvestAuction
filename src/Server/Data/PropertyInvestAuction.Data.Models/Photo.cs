namespace PropertyInvestAuction.Data.Models
{
    using System;

    using PropertyInvestAuction.Data.Common.Models;

    public class Photo : BaseModel<string>
    {
        public Photo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Url { get; set; }

        public string PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
