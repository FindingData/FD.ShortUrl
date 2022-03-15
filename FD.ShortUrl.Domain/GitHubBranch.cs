using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Domain
{
    /// <summary>
    /// A partial representation of a branch object from the GitHub API
    /// </summary>
    public class GitHubBranch
    {
        public string name { get; set; }
    }
}
