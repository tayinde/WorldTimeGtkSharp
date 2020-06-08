using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIRequest
{
    class DataToSend<type>
    {
        public type data;
        public DataToSend(type data)
        {
            this.data = data;
        }
    }
    public static class Request
    {
        static public dynamic city;
        static public async Task Send(string city)
        {
            string apiKey = "4a4a79f8b83a4125b46222602200606";
            string url = $"https://api.worldweatheronline.com/premium/v1/tz.ashx?q={city}&key={apiKey}&format=json";
            DataToSend<string> info = new DataToSend<string>("No data needed currently.");
            string json = JsonConvert.SerializeObject(info);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient Client = new HttpClient();
            var response = await Client.PostAsync(url, data);
            var covid = response.Content.ReadAsStringAsync().Result;
            JObject covidData = JObject.Parse(covid);
            Request.city = covidData;
        }
    }
}