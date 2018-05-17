using System.Collections.Generic;

namespace DAL.Entities
{
    public class Theatre
    {
        public int TheatreId { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public List<Play> Plays { get; set; }
    }
}
