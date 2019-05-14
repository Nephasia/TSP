using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPConsole {
    class Program {
        static void Main(string[] args) {
        }
    }


    class City {

        public string Name { get; private set; }
        List<Path> paths = new List<Path>();

        public City(string n) {
            Name = n;
        }

        public void AddBiDirectionalPath(City to, int distance) {
            this.AddOneDirectionPath(to, distance);
            to.AddOneDirectionPath(this, distance);
        }

        private void AddOneDirectionPath(City to, int distance) {
            paths.Add(new Path(to, distance));
        }


    }

    class Graph {

        List<City> cities = new List<City>();

        public int Count => cities.Count;

        public Graph this[int i] {
            get { return cities[i]; }
            //set { cities[i] = value; }
        }

        public void AddCity(string name) {
            City city = new City(name);
            cities.Add(city);
        }

        public List<City> GetCities() {
            return cities;
        }

        public City GetCity(City city) {
            return cities.Find(city);
        }

        public AddPath(City first, City second, int distance) {
            cities.Find(first).AddBiDirectionalPath(cities.Find(second), distance);
        }


    }

    class Path {

        City City { get; set; }
        public int Distance { get; set; }

        public Path(City city, int distance) {
            this.City = city;
            this.Distance = distance;
        }

    }

}
