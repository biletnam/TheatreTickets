using System.Collections.Generic;

namespace DAL.Entities
{
    public class Place
    {
        public int PlaceId { get; set; }
        public int Number { get; set; }
        public bool Buyed { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
