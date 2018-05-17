using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PlaceDTO
    {
        public int PlaceId { get; set; }
        public int Number { get; set; }
        public bool Buyed { get; set; }
        public int HallId { get; set; }
    }
}
