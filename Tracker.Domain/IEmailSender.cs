using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;

namespace Tracker.Domain
{
    public interface IEmailSender
    {
        void SendEmail(MessageDTO message);
        void SendEmailString(string message);
    }

}
