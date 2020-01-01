using System.Collections.Generic;
using System.Windows.Forms;
using RunnersWeather.CurrentConditions;
using RunnersWeather.Logger;
using RunnersWeather.Conditions;
using RunnersWeather.Decision;
using RunnersWeather.Location;
using System.Threading.Tasks;

namespace RunnersWeather
{
    public partial class MainWindow : Form
    {
        private readonly WindowFormConsoleLog ConsoleLoger;
        private readonly IConditionsChecker ConditionsChecker;
        public MainWindow()
        {
            InitializeComponent();
            InitializeCityList();
            ConsoleLoger = new WindowFormConsoleLog(ConsoleLogWindow);

            ConditionsChecker = new ConditionsChecker();
            ConditionsChecker.RegisterCurrentConditionProvider(new AirlyCurrentConditionsProvider());
            ConditionsChecker.RegisterCurrentConditionProvider(new OpenWeatherCurrentConditionsProvider());
        }

        private async void StartButton_Click(object sender, System.EventArgs e)
        {
            float lng = float.Parse(LongitudeTextBox.Text);
            float lat = float.Parse(LatitudeTextBox.Text);

            ConsoleLoger.AddEntry($"Checking conditions for long: {lng} and lat: {lat}");

            List<WeatherConditions> conditions = await ConditionsChecker.GetCurrentConditionsForCoordinates(lng, lat);

            PrintConditionsInfo(conditions);

            WeatherConditions averageWeatherConditions = AverageWeatherConditionsCalculator.Calculate(conditions);
            DecisionType calculatedDecision = DecisionMaker.CheckWeatherForRunning(averageWeatherConditions);

            PrintWeatherRecommendations(calculatedDecision);
        }

        private void PrintWeatherRecommendations(DecisionType calculatedDecision)
        {
            switch (calculatedDecision)
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

        private void LocationComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var selectedItem = (LocationItem)LocationComboBox.SelectedItem;

            LongitudeTextBox.Text = selectedItem.Longitude.ToString();
            LatitudeTextBox.Text = selectedItem.Lattitude.ToString();
        }

        private void InitializeCityList()
        {
            foreach (var location in LocationsProvider.GetSupportedLocations())
            {
                LocationComboBox.Items.Add(location);
            }
        }
        private void PrintConditionsInfo(List<WeatherConditions> conditions)
        {
            foreach (var condition in conditions)
            {
                ConsoleLoger.AddEntry("");
                ConsoleLoger.AddEntry($"Results from {condition.Provider}");
                ConsoleLoger.AddEntry($"PM25: {condition.PM25}");
                ConsoleLoger.AddEntry($"PM10: {condition.PM10}");
                ConsoleLoger.AddEntry($"TEMPERATURE [C]: {condition.TEMPERATURE}");
                ConsoleLoger.AddEntry($"HUMIDITY [%]: {condition.HUMIDITY}");
                ConsoleLoger.AddEntry($"WIND [m/s]: {condition.WIND}");
            }
        }
    }
}
