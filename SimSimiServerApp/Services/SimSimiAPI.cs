using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimSimiServerApp.Services
{
    public class SimSimiAPI : ISimSimiAPI
    {
        public ICollection<SimSimiMessage> Messages { get; set; }
        private HttpClient _httpClient { get; set; }

        public SimSimiAPI()
        {
            Messages = new List<SimSimiMessage>();
            _httpClient = new HttpClient();
        }

        public async Task<string> SendMessage(string message)
        {
            Messages.Add(new SimSimiMessage
            {
                User = "Me",
                Message = message,
                Date = DateTime.Now
            });

            var endpoint = $"https://api.simsimi.net/v1/?lang=es&cf=true&text={message}";          

            var httpResponse = await _httpClient.GetAsync(endpoint);

            if (!httpResponse.IsSuccessStatusCode)
                return String.Empty;

            var response = await httpResponse.Content.ReadAsStringAsync();

            var simSimiResponse = JsonSerializer.Deserialize<SimSimiResponse>(response);
            
            if (simSimiResponse.messages.FirstOrDefault().result == 100)
            {
                Messages.Add(new SimSimiMessage
                {
                    User = "Sim",
                    Message = simSimiResponse.messages.FirstOrDefault().text,
                    Date = DateTime.Now
                });
                return simSimiResponse.messages.FirstOrDefault().text;
            }

            return String.Empty;
        }
    }
}
