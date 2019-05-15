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
using System.Windows.Shapes;

namespace TSP
{
    /// <summary>
    /// Interaction logic for AddCityWindow.xaml
    /// </summary>
    public partial class AddCityWindow : Window
    {
        int pathsToFill;
        bool firstInit = true;

        int citiesAmount;

        public AddCityWindow()
        {
            InitializeComponent();
            pathsToFill = MainWindow.Instance.Graph.Count;
            citiesAmount = MainWindow.Instance.Graph.Count;
            Distance.Visibility = Visibility.Hidden;
            ToAdd.Content = "Remianing distances : " + pathsToFill;
            CityName.Content = "New city name : ";
            CityNameText.Text = "";
        }

        private void AddCity_Click(object sender, RoutedEventArgs e)
        {

            if (firstInit) {
                firstInit = false;
                MainWindow.Instance.Graph.AddCity(CityNameText.Text);
                
                if (pathsToFill == 0) {
                    CloseWindow();
                }

                ClearAndUpdate();
                Distance.Visibility = Visibility.Visible;
                
            } else {

                MainWindow.Instance.Graph.GetCity((string)(CityName.Content))
                    .AddBiDirectionalPath(MainWindow.Instance.Graph[citiesAmount], int.Parse(CityNameText.Text));

                ClearAndUpdate();

                if (pathsToFill == -1) {
                    CloseWindow();
                }
            }
            
        }

        void CloseWindow() {
            MainWindow.Instance.AddCitiesCount();
            MainWindow.Instance.AddCity.IsEnabled = true;
            this.Close();
        }

        void ClearAndUpdate() {
            pathsToFill--;
            CityNameText.Text = "";
            CityName.Content = MainWindow.Instance.Graph.GetAllCities()[citiesAmount - pathsToFill - 1].Name;
            ToAdd.Content = "Remianing distances : " + pathsToFill;
        }

        private void CityNameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            int a;

            if (firstInit) return;
            else if (int.TryParse(CityNameText.Text, out a)) AddCity.IsEnabled = true;
            else AddCity.IsEnabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.Instance.AddCity.IsEnabled = true;
        }
    }
}
