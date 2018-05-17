using System.Collections.Generic;

namespace DAL.Entities
{
    public class Play
    {
        public int PlayId { get; set; }
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public System.DateTime DateTime { get; set; }
    }
}
