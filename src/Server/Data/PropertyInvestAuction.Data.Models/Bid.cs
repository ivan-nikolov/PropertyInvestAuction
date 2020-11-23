namespace PropertyInvestAuction.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using PropertyInvestAuction.Data.Common.Models;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class Bid : BaseDeletableModel<string>
    {
        public Bid()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Range(typeof(decimal), BidMinPrice, BidMaxPrice)]
        public decimal BidPrice { get; set; }

        public string Comment { get; set; }

        public string OfferId { get; set; }
        public Offer Offer { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
