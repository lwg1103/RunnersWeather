using System.Windows.Forms;
using RunnersWeather.Logger;
using RunnersWeather.Smog;

namespace RunnersWeather
{
    public partial class MainWindow : Form
    {
        private WindowFormConsoleLog ConsoleLoger;
        private ISmogProvider AirlySmogProvider;
        public MainWindow()
        {
            InitializeComponent();
            ConsoleLoger = new WindowFormConsoleLog(ConsoleLogWindow);
            AirlySmogProvider = new AirlySmogProvider(ConsoleLoger);
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            float lng = float.Parse(LongitudeTextBox.Text);
            float lat = float.Parse(LatitudeTextBox.Text);

            AirlySmogProvider.GetCurrentSmogConditionsForCoordinates(lng, lat);
        }
    }
}
