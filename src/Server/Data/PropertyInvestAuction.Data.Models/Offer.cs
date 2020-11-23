namespace PropertyInvestAuction.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PropertyInvestAuction.Data.Common.Models;

    using static PropertyInvestAuction.Common.ValidationConstants;

    public class Offer : BaseDeletableModel<string>
    {
        public Offer()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Range(typeof(decimal), OfferStartingBidPrice, OfferBidOutPrice)]
        public decimal StartingBid { get; set; }

        [Range(typeof(decimal), OfferStartingBidPrice, OfferBidOutPrice)]
        public decimal BidOut { get; set; }
        
        public DateTime EndDate { get; set; }

        public string PropertyId { get; set; }
        public Property Property { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<Bid> Bids { get; set; } = new HashSet<Bid>();
    }
}
