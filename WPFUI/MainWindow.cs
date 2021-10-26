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

        private async Task LoadHomePage()
        {
            WeatherModel weatherModel = await WeatherProcessor.LoadWeatherModels("forecast", "efd1bc2dfe4c4a42a9c183606213108", "91355", 3, "no", "no");

            // create URI for conditionIcon
            var uriSource = new Uri($"https:{ weatherModel.Current.Condition.Icon }", UriKind.Absolute);

            conditionIcon.Source = new BitmapImage(uriSource);
            conditionText.Text = weatherModel.Current.Condition.Text;
            nameRegion.Text = $"{weatherModel.Location.Name}, {weatherModel.Location.Region}";
            feelsLikeF.Text = $"Feels like {weatherModel.Current.feelslike_f}\x00B0";
            humidity.Text = $"Humidity {weatherModel.Current.humidity}%";
            windMPH.Text = $"Wind {weatherModel.Current.wind_mph} mph";
            tempF.Text = $"{weatherModel.Current.temp_f.ToString()}\x00B0";


            // 7 day stuffs

            for (int i = 0; i < weatherModel.Forecast.ForecastDay.Count; ++i)
            {
                var forecastUriSource = new Uri($"https:{weatherModel.Forecast.ForecastDay[i].Day.Condition.Icon}", UriKind.Absolute);

                StackPanel dayPanel = new StackPanel();
                StackPanel highLowPanel = new StackPanel();
                TextBlock date = new TextBlock();
                TextBlock high = new TextBlock();
                TextBlock low = new TextBlock();
                TextBlock slash = new TextBlock();
                TextBlock condition = new TextBlock();
                Image icon = new Image();

                date.Style = (Style)FindResource("forecastMainTextBlock");
                high.Style = (Style)FindResource("forecastMainTextBlock");
                low.Style = (Style)FindResource("forecastLowTempTextBlock");
                slash.Style = (Style)FindResource("forecastLowTempTextBlock");
                condition.Style = (Style)FindResource("forecastConditionTextBlock");
                highLowPanel.Style = (Style)FindResource("highLowStackPanel");
                icon.Style = (Style)FindResource("forecastIcon");

                icon.Source = new BitmapImage(forecastUriSource);
                date.Text = weatherModel.Forecast.ForecastDay[i].Date.ToString("ddd");
                high.Text = $"{weatherModel.Forecast.ForecastDay[i].Day.maxtemp_f.ToString()}\x00B0";
                low.Text = $"{weatherModel.Forecast.ForecastDay[i].Day.mintemp_f.ToString()}\x00B0";
                condition.Text = weatherModel.Forecast.ForecastDay[i].Day.Condition.Text;
                slash.Text = "/";
                
                highLowPanel.Children.Add(high);
                highLowPanel.Children.Add(slash);
                highLowPanel.Children.Add(low);

                dayPanel.Children.Add(date);
                dayPanel.Children.Add(icon);
                dayPanel.Children.Add(highLowPanel);
                dayPanel.Children.Add(condition);


                // put in 7 day panel
                homeForecastStackPanel.Children.Add(dayPanel);
            }

            //day1Day.Text = weatherModel.Forecast.ForecastDay[0].Date.ToString("ddd");
            //day1TempHigh.Text = weatherModel.Forecast.ForecastDay[0].Day.maxtemp_f.ToString();
            //day1TempLow.Text = weatherModel.Forecast.ForecastDay[0].Day.mintemp_f.ToString();
            //day1Text.Text = weatherModel.Forecast.ForecastDay[0].Day.Condition.Text;

        }

        //private async Task LoadForecast()
        //{

        //}

        private async Task LoadHomePage(string ZIPCode)
        {
            WeatherModel weatherModel = await WeatherProcessor.LoadWeatherModels("forecast", "efd1bc2dfe4c4a42a9c183606213108", ZIPCode, 3, "no", "no");

            // create URI for conditionIcon
            var uriSource = new Uri($"https:{ weatherModel.Current.Condition.Icon }", UriKind.Absolute);

            conditionIcon.Source = new BitmapImage(uriSource);
            conditionText.Text = weatherModel.Current.Condition.Text;
            nameRegion.Text = $"{weatherModel.Location.Name}, {weatherModel.Location.Region}";
            feelsLikeF.Text = $"Feels like {weatherModel.Current.feelslike_f}\x00B0";
            humidity.Text = $"Humidity {weatherModel.Current.humidity}%";
            windMPH.Text = $"Wind {weatherModel.Current.wind_mph} mph";
            tempF.Text = $"{weatherModel.Current.temp_f.ToString()}\x00B0";


            // 7 day stuffs

            for (int i = 0; i < weatherModel.Forecast.ForecastDay.Count; ++i)
            {
                var forecastUriSource = new Uri($"https:{weatherModel.Forecast.ForecastDay[i].Day.Condition.Icon}", UriKind.Absolute);

                StackPanel dayPanel = new StackPanel();
                StackPanel highLowPanel = new StackPanel();
                TextBlock date = new TextBlock();
                TextBlock high = new TextBlock();
                TextBlock low = new TextBlock();
                TextBlock slash = new TextBlock();
                TextBlock condition = new TextBlock();
                Image icon = new Image();

                date.Style = (Style)FindResource("forecastMainTextBlock");
                high.Style = (Style)FindResource("forecastMainTextBlock");
                low.Style = (Style)FindResource("forecastLowTempTextBlock");
                slash.Style = (Style)FindResource("forecastLowTempTextBlock");
                condition.Style = (Style)FindResource("forecastConditionTextBlock");
                highLowPanel.Style = (Style)FindResource("highLowStackPanel");
                icon.Style = (Style)FindResource("forecastIcon");

                icon.Source = new BitmapImage(forecastUriSource);
                date.Text = weatherModel.Forecast.ForecastDay[i].Date.ToString("ddd");
                high.Text = $"{weatherModel.Forecast.ForecastDay[i].Day.maxtemp_f.ToString()}\x00B0";
                low.Text = $"{weatherModel.Forecast.ForecastDay[i].Day.mintemp_f.ToString()}\x00B0";
                condition.Text = weatherModel.Forecast.ForecastDay[i].Day.Condition.Text;
                slash.Text = "/";

                highLowPanel.Children.Add(high);
                highLowPanel.Children.Add(slash);
                highLowPanel.Children.Add(low);

                dayPanel.Children.Add(date);
                dayPanel.Children.Add(icon);
                dayPanel.Children.Add(highLowPanel);
                dayPanel.Children.Add(condition);


                // put in 7 day panel
                homeForecastStackPanel.Children.Add(dayPanel);
            }

            //day1Day.Text = weatherModel.Forecast.ForecastDay[0].Date.ToString("ddd");
            //day1TempHigh.Text = weatherModel.Forecast.ForecastDay[0].Day.maxtemp_f.ToString();
            //day1TempLow.Text = weatherModel.Forecast.ForecastDay[0].Day.mintemp_f.ToString();
            //day1Text.Text = weatherModel.Forecast.ForecastDay[0].Day.Condition.Text;

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadHomePage();
            // LoadHomePage(ZIPCode.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
        }

    }
}
