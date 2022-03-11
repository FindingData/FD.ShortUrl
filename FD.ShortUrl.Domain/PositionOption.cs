using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Domain
{    
    public class PositionOption
    {
        public const string PositionOptions = "PositionOptions";
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        [Range(0, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? Value { get; set; }
        public int? Value2 { get; set; }
    }     
}
