using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunnersWeather
{
    public class ConsoleLog
    {
        private TextBox textBox;
        public ConsoleLog(TextBox textBox) => this.textBox = textBox;
        
        public void AddEntry(string message)
        {
            textBox.Text += System.Environment.NewLine + message;
        }

        public void Clear()
        {
            textBox.Text = "";
        }
    }
}
