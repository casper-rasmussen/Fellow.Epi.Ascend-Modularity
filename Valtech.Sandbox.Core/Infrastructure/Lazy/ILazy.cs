using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valtech.Sandbox.Core.Infrastructure.Lazy
{
    public interface ILazy<out T>
    {
        T Service { get; }

    }
}
