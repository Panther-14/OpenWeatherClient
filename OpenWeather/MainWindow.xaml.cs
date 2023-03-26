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
            if (!string.IsNullOrWhiteSpace(txtCity.Text))
            {
                try
                {
                    WeatherOneDayResponse weather = await WeatherService.CheckOneDayWeather(txtCity.Text);
                    if(weather.Main != null)
                    {
                        this.lbMin2.Content = $"Minima: {weather.Main.TempMin}";
                        this.lbMax2.Content = $"Máxima: {weather.Main.TempMax}";
                        this.imgWeather2.Source = WeatherService.GetBitmapImage(weather.Weathers[0].Icon);
                    }
                }
                catch
                {
                    MessageBox.Show("No se pudo acceder al contenido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
                

        private async void btnFiveDays_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCity.Text))
            {
                try
                {
                    WeatherFiveDaysResponse weather = await WeatherService.CheckFiveDaysWeather(txtCity.Text);
                    if (weather.List.Any())
                    {
                        this.lbMin0.Content = $"Minima: {weather.List[5].Main.TempMin}";
                        this.lbMax0.Content = $"Máxima: {weather.List[5].Main.TempMax}";
                        this.imgWeather0.Source = WeatherService.GetBitmapImage(weather.List[5].Weathers[0].Icon);

                        this.lbMin1.Content = $"Minima: {weather.List[13].Main.TempMin}";
                        this.lbMax1.Content = $"Máxima: {weather.List[13].Main.TempMax}";
                        this.imgWeather1.Source = WeatherService.GetBitmapImage(weather.List[13].Weathers[0].Icon);

                        this.lbMin2.Content = $"Minima: {weather.List[21].Main.TempMin}";
                        this.lbMax2.Content = $"Máxima: {weather.List[21].Main.TempMax}";
                        this.imgWeather2.Source = WeatherService.GetBitmapImage(weather.List[21].Weathers[0].Icon);

                        this.lbMin3.Content = $"Minima: {weather.List[29].Main.TempMin}";
                        this.lbMax3.Content = $"Máxima: {weather.List[29].Main.TempMax}";
                        this.imgWeather3.Source = WeatherService.GetBitmapImage(weather.List[29].Weathers[0].Icon);

                        this.lbMin4.Content = $"Minima: {weather.List[37].Main.TempMin}";
                        this.lbMax4.Content = $"Máxima: {weather.List[37].Main.TempMax}";
                        this.imgWeather4.Source = WeatherService.GetBitmapImage(weather.List[37].Weathers[0].Icon);
                    }
                }
                catch
                {
                    MessageBox.Show("No se pudo acceder al contenido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
