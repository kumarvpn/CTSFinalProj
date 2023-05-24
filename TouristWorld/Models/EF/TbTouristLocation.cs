using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TouristWorld.Models.EF
{
    public partial class TbTouristLocation
    {
        public int PlaceId { get; set; }
        public string LocationName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string LocationImage { get; set; }
    }
}
