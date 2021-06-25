using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimSimiServerApp.Services
{
    public interface ISimSimiAPI
    {
        ICollection<SimSimiMessage> Messages { get; set; }
        Task<string> SendMessage(string message);
    }
}
