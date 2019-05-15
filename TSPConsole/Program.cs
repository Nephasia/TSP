using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPConsole.Objects;

namespace TSPConsole {
    public class Program
    {

        static void Main(string[] args)
        {
            Graph graph = new Graph();

            City a = new City("A");
            City b = new City("B");
            City c = new City("C");
            City d = new City("D");

            graph.AddCity(a);
            graph.AddCity(b);
            graph.AddCity(c);
            graph.AddCity(d);

            graph.AddPath(a, b, 10);
            graph.AddPath(a, c, 15);
            graph.AddPath(a, d, 20);

            graph.AddPath(b, c, 35);
            graph.AddPath(b, d, 25);

            graph.AddPath(c, d, 30);

            //graph.ShowAllDistances();

        //    int shortestPath = ShortestPath(graph, "A");

        //    Console.WriteLine("Distance of this path is equal to: " + shortestPath);

            Console.ReadKey();
        }

        public static Tuple<int, string> ShortestPath(Graph graph, string startCityName) {

            int n = graph.Count;
            List<City> path = new List<City>();
            
            int overallDistance = 0;
            int lastIndex = 0;
            int finishIndex = 0; // index of last visited vertex of DFS
            int minCurrentDistance = Int32.MaxValue; // temp value for finding minimal value

            City startCity = graph.GetCity(startCityName);
            startCity.VisitIt();
            path.Add(startCity);
            
            for (int i = 0; i < n; i++)
            {
                List<Path> allPaths = graph[i].GetAllPaths();
                for (int j = 0; j < allPaths.Count; j++)
                {
                    if (!allPaths[j].City.IsVisited)
                    {
                        if (allPaths[j].Distance < minCurrentDistance)
                        {
                            minCurrentDistance = allPaths[j].Distance;
                            lastIndex = j;
                        }
                    }
                }

                if (!allPaths[lastIndex].City.IsVisited) {

                    allPaths[lastIndex].City.VisitIt();
                    path.Add(allPaths[lastIndex].City);
                    overallDistance += minCurrentDistance;

                    minCurrentDistance = Int32.MaxValue;

                    i = lastIndex;
                    finishIndex = lastIndex;
                    lastIndex = 0;
                   
                }
                if (i == n - 1)
                {
                    path.Add(startCity);
                    overallDistance+= graph[finishIndex].GetAllPaths()[0].Distance;
                }

            }

            string pathString = "";

            for (int i = 0; i < path.Count; i++) {
                pathString += path[i].Name + (i != path.Count - 1 ? "->" : "");
            }

            Tuple<int, string> d = new Tuple<int, string> ( overallDistance, pathString );

            return d;
        }

    }

}
