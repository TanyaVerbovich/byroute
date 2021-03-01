using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp3.Models
{
    public class Route
    {
        public int id { set; get; }
        public string Name { set; get; }
        public int HowManyPlaces { set; get; }
        public string place { set; get; }
        public DateTime datafrom { get; set; }
        public ushort Price { set; get; }
        public long Telephone { set; get; }
        public bool isFav { get; set; }

    }
}
