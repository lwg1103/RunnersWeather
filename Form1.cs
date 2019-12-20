using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunnersWeather
{
    public partial class MainWindow : Form
    {
        private ConsoleLog ConsoleLoger;
        public MainWindow()
        {
            InitializeComponent();
            ConsoleLoger = new ConsoleLog(ConsoleLogWindow);
            ConsoleLoger.AddEntry("Hi!");
            ConsoleLoger.AddEntry("Let's start!");
        }
    }
}
