using System.Collections.Generic;
using System.Windows.Forms;
using RunnersWeather.CurrentConditions;
using RunnersWeather.Logger;
using RunnersWeather.Conditions;
using RunnersWeather.Decision;

namespace RunnersWeather
{
    public partial class MainWindow : Form
    {
        private readonly WindowFormConsoleLog ConsoleLoger;
        private readonly ICurrentConditionsProvider AirlyProvider;
        private readonly ICurrentConditionsProvider OpenWeatherProvider;
        public MainWindow()
        {
            InitializeComponent();
            ConsoleLoger = new WindowFormConsoleLog(ConsoleLogWindow);
            AirlyProvider = new AirlyCurrentConditionsProvider(ConsoleLoger);
            OpenWeatherProvider = new OpenWeatherCurrentConditionsProvider(ConsoleLoger);
        }

        private async void StartButton_Click(object sender, System.EventArgs e)
        {
            float lng = float.Parse(LongitudeTextBox.Text);
            float lat = float.Parse(LatitudeTextBox.Text);

            WeatherConditions airlyConditions = await AirlyProvider.GetCurrentConditionsForCoordinates(lng, lat);
            WeatherConditions openWeatherCondistions = await OpenWeatherProvider.GetCurrentConditionsForCoordinates(lng, lat);
            
            List<WeatherConditions> conditions = new List<WeatherConditions>();
            conditions.Add(airlyConditions);
            conditions.Add(openWeatherCondistions);

            WeatherConditions averageWeatherConditions = AverageWeatherConditionsCalculator.Calculate(conditions);

            switch (DecisionMaker.CheckWeatherForRunning(averageWeatherConditions))
            {
                case DecisionType.OK:
                    ConsoleLoger.AddEntry("It's a good weather for running!");
                    break;
                case DecisionType.LowSmog:
                    ConsoleLoger.AddEntry("It's NOT good weather for running but with smog mask you can go!");
                    break;
                case DecisionType.HeavySmog:
                    ConsoleLoger.AddEntry("It's NOT good weather for running, too much SMOG!");
                    break;
                case DecisionType.TooCold:
                    ConsoleLoger.AddEntry("It's NOT good weather for running, it's TOO COLD!");
                    break;
                case DecisionType.TooHot:
                    ConsoleLoger.AddEntry("It's NOT good weather for running, it's TOO HOT!");
                    break;
                case DecisionType.Rain:
                    ConsoleLoger.AddEntry("It's NOT good weather for running, it's RAINING!");
                    break;
            }
        }
    }
}
