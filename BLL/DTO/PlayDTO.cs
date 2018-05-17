namespace BLL.DTO
{
    public class PlayDTO
    {
        public int PlayId { get; set; }
        public int TheatreId { get; set; }
        public int HallId { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public System.DateTime DateTime { get; set; }
    }
}
