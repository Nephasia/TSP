using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPConsole {
    class Program {
        static void Main(string[] args) {

            Graph graph = new Graph();

            graph.AddCity("A");

            City b = new City("B");
            graph.AddCity(b);
            graph.AddPath(graph.GetCity("A"), b, 3);

            City c = new City("C");
            graph.AddCity(c);
            graph.AddPath(graph.GetCity("A"), c, 7);

            City d = new City("D");
            graph.AddCity(d);
            graph.AddPath(b, d, 2);

            graph.ShowAllDistances();

            Console.WriteLine();
            Console.WriteLine();

            graph.GetCity("B").ShowAllDistances();

            Console.ReadKey();
        }
    }


    class City : IEnumerable<Path> {

        public string Name { get; private set; }
        List<Path> paths = new List<Path>();

        public City(string n) {
            Name = n;
        }

        public List<Path> GetAllPaths() {
            return paths;
        }

        public void AddBiDirectionalPath(City to, int distance) {
            this.AddOneDirectionPath(to, distance);
            to.AddOneDirectionPath(this, distance);
        }

        private void AddOneDirectionPath(City to, int distance) {
            paths.Add(new Path(to, distance));
        }

        public IEnumerator<Path> GetEnumerator() {
            for (int i = 0; i < paths.Count; i++) {
                yield return paths[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        public void ShowAllDistances() {
            foreach (var path in paths) {
                Console.WriteLine(Name + " has path to " + path.City.Name + " with distance of : " + path.Distance);
            }
        }

    }

    class Graph {

        List<City> cities = new List<City>();

        public int Count => cities.Count;

        public City this[int i] {
            get { return cities[i]; }
            //set { cities[i] = value; }
        }

        public void AddCity(City city) {
            cities.Add(city);
        }
        public void AddCity(string name) {
            City city = new City(name);
            cities.Add(city);
        }

        public List<City> GetAllCities() {
            return cities;
        }

        public City GetCity(City city) {

            City wantedCity = null;
            try {
                wantedCity = cities.Find(c => c.Name == city.Name);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            } 
            return wantedCity;

        }
        public City GetCity(string withName) {
            return cities.Find(c => c.Name == withName);
        }

        public void AddPath(City first, City second, int distance) {
            if(first == null || second == null) {
                Console.WriteLine("CITY NOT FOUND !!!!");
            } else 
                cities.Find(x => x.Name == first.Name).AddBiDirectionalPath(cities.Find(x => x.Name == second.Name), distance);
        }
        public void AddPath(string firstCityName, string secondCityName, int distance) {
            if (firstCityName == null || secondCityName == null) {
                Console.WriteLine("CITY NOT FOUND !!!!");
            } else
                cities.Find(x => x.Name == firstCityName).AddBiDirectionalPath(cities.Find(x => x.Name == secondCityName), distance);
        }

        public void ShowAllDistances() {
            foreach(var item in cities) {

                foreach(var path in item) {
                    Console.WriteLine(item.Name + " has path to " + path.City.Name + " with distance of : " + path.Distance);
                }

            }
        }

    }

    class Path {

        public City City { get; set; }
        public int Distance { get; set; }

        public Path(City city, int distance) {
            this.City = city;
            this.Distance = distance;
        }

    }

}
