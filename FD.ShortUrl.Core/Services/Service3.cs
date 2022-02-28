using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Core
{
    public class Service3 : IService3, IDisposable
    {
        private bool _disposed;

        public Service3(string myKey)
        {
            MyKey = myKey;
        }

        public string MyKey { get; }

        public void Write(string message)
        {
            Console.WriteLine($"Service3: {message}, MyKey = {MyKey}");
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            Console.WriteLine("Service3.Dispose");
            _disposed = true;
        }
    }
}
