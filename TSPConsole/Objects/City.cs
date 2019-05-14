using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPConsole.Objects {
    public class City : IEnumerable<Path> {

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
}
