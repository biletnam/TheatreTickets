using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Models
{
    public class PlaceComparator : IComparer<PlaceViewModel>
    {
        public int Compare(PlaceViewModel x, PlaceViewModel y)
        {
            return x.Number - y.Number;
        }
    }
}
