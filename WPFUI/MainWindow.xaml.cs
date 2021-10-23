using DemoLibrary;
using JMAPILibrary;
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

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            APIHelper.InitializeClient();
        }

        private async Task LoadCurrentWeather()
        {
            WeatherModel weatherModel = await WeatherProcessor.LoadWeatherModels();

            // create URI for conditionIcon
            var uriSource = new Uri($"https:{ weatherModel.Current.Condition.Icon }", UriKind.Absolute);

            conditionIcon.Source = new BitmapImage(uriSource);
            conditionText.Text = weatherModel.Current.Condition.Text;

            tempF.Text = weatherModel.Current.temp_f.ToString();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadCurrentWeather();
        }
    }
}
