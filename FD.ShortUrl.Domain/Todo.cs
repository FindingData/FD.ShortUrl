using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Domain
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
        [Required]
        public string? Desc { get; set; }
    }
}
