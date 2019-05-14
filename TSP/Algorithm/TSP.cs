using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP.Algorithm
{
    class TSP
    {

        Graph graph = new Graph ();


        public int TravellingSP(Graph g, int start)
        {
            int min_path = Int32.MaxValue;

            int current_path = 0;
            int[] sciezki = new int[100];
            for (int i = 0; i < g.Count; i++)
            {
                for (int j = 0; j < g.Count; j++)
                {

                }
            }
           

        }

        int travllingSalesmanProblem(int graph[][V], int s)
        {
            //// store all vertex apart from source vertex 
            //vector<int> vertex;
            //for (int i = 0; i < V; i++)
            //    if (i != s)
            //        vertex.push_back(i);

            // store minimum weight Hamiltonian Cycle. 
            int min_path = INT_MAX;
            do
            {

                // store current Path weight(cost) 
                int current_pathweight = 0;

                // compute current path weight 
                int k = s;
                for (int i = 0; i < vertex.size(); i++)
                {
                    current_pathweight += graph[k][vertex[i]];
                    k = vertex[i];
                }
                current_pathweight += graph[k][s];

                // update minimum 
                min_path = min(min_path, current_pathweight);

            } while (next_permutation(vertex.begin(), vertex.end()));

            return min_path;
        }


    }

    class City {

        public string Name { get; private set; }
        List<Path> paths = new List<Path>();

        public City(string n){
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
