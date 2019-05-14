using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPConsole.Objects {
    public class Path {

        public City City { get; set; }
        public int Distance { get; set; }

        public Path(City city, int distance) {
            this.City = city;
            this.Distance = distance;
        }

    }

}
