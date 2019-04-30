using AzShip.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzShip.Core.Models
{
    public class Cargo : EntityGuid
    {
        public Cargo()
        {

        }

        public Cargo(string title, string description, decimal price)
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;
        }

        public Cargo InformAddresses(string sourceAddress, string destinationAddress)
        {
            this.SourceAddress = sourceAddress;
            this.DestinationAddress = destinationAddress;
            return this;
        }

        public Cargo InformContactInfo(string email)
        {
            this.ContactEmail = email;
            return this;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string ContactEmail { get; set; }
    }
}
