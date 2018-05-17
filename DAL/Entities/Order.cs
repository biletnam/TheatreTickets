using System.Collections.Generic;

namespace DAL.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
