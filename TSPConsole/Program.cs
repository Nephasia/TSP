using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPConsole.Objects;

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

            d.AddBiDirectionalPath(graph.GetCity("A"), 13);

            graph.ShowAllDistances();

            Console.WriteLine();
            Console.WriteLine();

            graph.GetCity("B").ShowAllDistances();

            Console.ReadKey();
        }
    }

}
