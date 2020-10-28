using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Exceptions
{
    public class ServiceLogicException : Exception
    {
        public ServiceLogicException(string message) : base(message) {}
    }
}
