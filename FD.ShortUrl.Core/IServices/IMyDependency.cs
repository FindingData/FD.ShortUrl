using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Core
{
    public interface IMyDependency
    {
        void WriteMessage(string message);
    }
}
