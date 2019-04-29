using AzShip.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzShip.Core.Models
{
    public class Cargo : EntityGuid
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string ContactEmail { get; set; }
    }
}
