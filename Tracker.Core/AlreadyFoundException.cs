using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Core
{
    class AlreadyFoundException:Exception
    {
        public AlreadyFoundException(string message)
            : base(message)
        { }
    }
}
