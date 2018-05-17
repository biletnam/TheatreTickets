using System;
namespace PL.Models
{
    public class PlayViewModel
    {
        public int PlayId { get; set; }
        public int HallId { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}
