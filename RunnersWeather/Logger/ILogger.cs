using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnersWeather.Logger
{
    public interface ILogger
    {
        void AddEntry(string message);
        void Clear();
    }
}
