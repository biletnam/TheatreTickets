using System.Collections.Generic;

namespace PL.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PlaceId { get; set; }

        public int Number { get; set; }
        public int NumberRow { get; set; }
    }
}
