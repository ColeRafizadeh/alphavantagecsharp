using System;
using System.Collections.Generic;
using models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace models
{

    public class StockData
    {
        [JsonProperty("Meta Data")]
        public MetaData MetaData { get; set; }

        [JsonProperty("Weekly Time Series")]
        public Dictionary<string, WeeklyTimeSery> WeeklyTimeSeries { get; set; }
    }

    public class MetaData
    {
        [JsonProperty("1. Information")]
        public string The1Information { get; set; }

        [JsonProperty("2. Symbol")]
        public string The2Symbol { get; set; }

        [JsonProperty("3. Last Refreshed")]
        public DateTimeOffset The3LastRefreshed { get; set; }

        [JsonProperty("4. Time Zone")]
        public string The4TimeZone { get; set; }
    }

    public class WeeklyTimeSery
    {
        [JsonProperty("1. open")]
        public string The1Open { get; set; }

        [JsonProperty("2. high")]
        public string The2High { get; set; }

        [JsonProperty("3. low")]
        public string The3Low { get; set; }

        [JsonProperty("4. close")]
        public string The4Close { get; set; }

        [JsonProperty("5. volume")]
        public long The5Volume { get; set; }
    }
}

namespace rest
{

    class Program
    {
        public static void QuestionOne()
        {
            string ticker = "msft";
            string key = "650CS2ENBH9B4PB1";
            var client = new RestClient("https://www.alphavantage.co/query?");
            var request = new RestRequest(Method.GET);
            request.AddParameter("symbol", ticker);
            request.AddParameter("apikey", key);
            request.AddParameter("function", "TIME_SERIES_DAILY");
            request.AddParameter("outputsize", "compact");
            request.AddParameter("datatype", "json");
            IRestResponse response = client.Execute(request);
            StockData data = JsonConvert.DeserializeObject<StockData>(response.Content);


            

        }

        static public void Main(String[] args)
        {
            QuestionOne();
        }
    }
}