using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Domain
{
    public class TopItemSettings
    {
        public const string Month = "Month";
        public const string Year = "Year";

        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
    }
}
