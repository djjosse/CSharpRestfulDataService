using Shenkar.RestfulServices;
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

namespace RestfulService.WPFAppExample
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

        private void GetData(object sender, RoutedEventArgs e)
        {
            //get data for given location
            string loc = locTxtBox.Text.ToString();
            try
            {
                if (!String.IsNullOrEmpty(loc))
                {
                    Location location = new Location(loc);
                    IWeatherDataService service = WeatherDataService.Instance;
                    WeatherData data = service.GetWeatherData(location);

                    line1Lbl.Content = String.Format("Location: {0}, {1}", data.Location.CityName, data.Location.Country);
                    line2Lbl.Content = String.Format("Last Update: {0}", data.LastUpdate.ToString());
                    line3Lbl.Content = String.Format("Temperature: {0} {1}, humidity: {2}{3}",
                        data.Temperature.AverageTemperature, data.Temperature.TemperatureUnit, data.HumidityValue, data.HumidityUnit);
                    line4Lbl.Content = String.Format("Pressure: {0} {1}",
                        data.PressureValue, data.PressureUnit);
                    line5Lbl.Content = String.Format("Wind speed {0} {1}, direction: {2}",
                        data.Wind.Speed, data.Wind.SpeedDescription, data.Wind.Direction);
                    
                }
            }
            catch (WeatherDataServiceException)
            {
                MessageBoxResult result = MessageBox.Show(
                    String.Format("Provided location: \"{0}\" is invalid. Please try again!", loc),
                        "Error", MessageBoxButton.OK, MessageBoxImage.Question);

            }
        }
    }
}
