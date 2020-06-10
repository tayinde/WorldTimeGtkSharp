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
        static public JObject location;
        static public async Task Send(string city)
        {
            Key key = new Key();
            key.setValue("public key"); // "public key" can be replaced with a custom key
            string apiKey = key.value;
            string url = $"https://api.worldweatheronline.com/premium/v1/tz.ashx?q={city}&key={apiKey}&format=json";
            DataToSend<string> info = new DataToSend<string>("No data needed currently.");
            string json = JsonConvert.SerializeObject(info);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient Client = new HttpClient();
            HttpResponseMessage response = await Client.PostAsync(url, data);
            string cityJSON = response.Content.ReadAsStringAsync().Result;
            JObject cityData = JObject.Parse(cityJSON);
            Request.location = cityData;
        }
    }
}