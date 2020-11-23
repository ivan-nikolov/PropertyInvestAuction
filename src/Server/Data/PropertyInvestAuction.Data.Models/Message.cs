namespace PropertyInvestAuction.Data.Models
{
    using System;

    using PropertyInvestAuction.Data.Common.Models;

    public class Message : BaseDeletableModel<string>
    {
        public Message()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SenderId { get; set; }
        public AppUser Sender { get; set; }

        public string ReceiverId { get; set; }
        public AppUser Receiver { get; set; }
    }
}
