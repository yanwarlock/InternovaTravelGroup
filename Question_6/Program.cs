using Microsoft.Azure.EventGrid.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Question_6
{
    static class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            Console.WriteLine($"Question_6");
            var PROJECTNAME = "";
            var eventGridEvent = new EventGridEvent()
            {
                Id = "1",
                DataVersion = "1.0",
                EventTime = DateTime.Now,
                EventType = "Info",
                Subject = "echo",
                Data = new
                {
                    value = "Info"
                },
            };
            var json = JsonConvert.SerializeObject(eventGridEvent);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

            var response = await _httpClient.PostAsync($"http://{PROJECTNAME}.azurewebsites.net/api/TestFunction",data);
            var result = await response.Content.ReadAsStringAsync();    
            Console.WriteLine(result);
        }
    }
}
