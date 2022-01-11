using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Core
{
    public class NotCompletedException : Exception
    {
        public NotCompletedException()
        { }

        public NotCompletedException(string message)
            : base(message)
        { }

        public NotCompletedException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
