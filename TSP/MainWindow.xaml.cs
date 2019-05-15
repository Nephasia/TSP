using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TSPConsole.Objects;

namespace TSP {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static MainWindow Instance {
            get {
                return _Instance;
            }
        } private static MainWindow _Instance;

        public int addedCities;

        public Graph Graph {
            get;
        }

        public MainWindow()
        {
            if (_Instance == null) {
                InitializeComponent();
                _Instance = this;
                Graph = new Graph();
                FindPath.IsEnabled = false;
                ShortestPath.Visibility = Visibility.Hidden;
            }
        }

        public void AddCitiesCount() {
            addedCities++;
            CitiesAdded.Content = addedCities;
            if(addedCities > 2) FindPath.IsEnabled = true;
        }

        private void NumberOfCities_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddCity_Click(object sender, RoutedEventArgs e)
        {
            AddCityWindow addCityWindow = new AddCityWindow();
            addCityWindow.Show();
        }

        private void FindPath_Click(object sender, RoutedEventArgs e)
        {
            Tuple<int, string> value = TSPConsole.Program.ShortestPath(Graph, Graph[0].Name);
            AddCity.IsEnabled = false;
            FindPath.Visibility = Visibility.Hidden;
            ShortestPath.Visibility = Visibility.Visible;
            ShortestPath.Content =
                "Path length : " +
                value.Item1.ToString() +
                System.Environment.NewLine +
                value.Item2
            ;
            

        }
    }
}
