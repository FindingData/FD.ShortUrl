using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Core
{
    public interface IOperation
    {
        string OperationId { get; }
    }

    public interface IOperationTransient : IOperation { }
    public interface IOperationScoped : IOperation { }
    public interface IOperationSingleton : IOperation { }
}
