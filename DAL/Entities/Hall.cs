using System.Collections.Generic;

namespace DAL.Entities
{
    public class Hall
    {
        public int HallId { get; set; }
        public string Name { get; set; }
        public Play Play { get; set; }
        public List<Place> Places { get; set; }
    }
}
