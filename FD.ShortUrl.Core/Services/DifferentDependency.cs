using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Core
{
    public class DifferentDependency : IMyDependency
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"DifferentDependency.WriteMessage Message: {message}");
        }
    }
}
