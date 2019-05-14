using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPConsole.Objects {
    public class Graph {

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
            return GetCity(city.Name);
        }
        public City GetCity(string withName) {

            City city = cities.Find(c => c.Name == withName);
            if (city == null) Console.WriteLine($"City of name : {withName} not found");
            return city;
        }

        public void AddPath(City first, City second, int distance) {
            if (first == null || second == null) {
                throw new System.NullReferenceException();
            } else
                cities.Find(x => x.Name == first.Name).AddBiDirectionalPath(cities.Find(x => x.Name == second.Name), distance);
        }
        public void AddPath(string firstCityName, string secondCityName, int distance) {
            if (firstCityName == null || secondCityName == null) {
                throw new System.NullReferenceException();
            } else
                cities.Find(x => x.Name == firstCityName).AddBiDirectionalPath(cities.Find(x => x.Name == secondCityName), distance);
        }

        public void ShowAllDistances() {
            foreach (var item in cities) {

                foreach (var path in item) {
                    Console.WriteLine(item.Name + " has path to " + path.City.Name + " with distance of : " + path.Distance);
                }

            }
        }

    }
}
