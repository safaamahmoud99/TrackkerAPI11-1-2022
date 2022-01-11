using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Core
{
    public class NotExistException : Exception
    {
        public NotExistException()
        { }

        public NotExistException(string message)
            : base(message)
        { }

        public NotExistException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
