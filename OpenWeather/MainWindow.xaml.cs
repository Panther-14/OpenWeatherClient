using OpenWeather.Model.api;
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

namespace OpenWeather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void btnNow_Click(object sender, RoutedEventArgs e)
        {
            WeatherOneDayResponse weather = await WeatherService.CheckOneDayWeather("Mexico City");
            txtWeather.Text = weather.ToString();
        }

        private async void btnFiveDays_Click(object sender, RoutedEventArgs e)
        {
            WeatherFiveDaysResponse weather = await WeatherService.CheckFiveDaysWeather("Mexico City");
            txtWeather.Text = weather.ToString();
        }
    }
}
