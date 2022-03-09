using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Domain
{    
    public class PositionOption
    {
        public const string PositionOptions = "PositionOptions";
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;

        public int? Value { get; set; }

    }     
}
