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

        [JsonProperty("Time Series (Daily)")]
        public List<DailyData> TimeSeries { get; set; }
    }

    public class MetaData
    {
        [JsonProperty("1. Information")]
        public string Information { get; set; }

        [JsonProperty("2. Symbol")]
        public string Symbol { get; set; }

        [JsonProperty("3. Last Refreshed")]
        public DateTimeOffset LastRefreshed { get; set; }

        [JsonProperty("4. Time Zone")]
        public string TimeZone { get; set; }
    }

    public class DailyData
    {
        [JsonProperty("1. open")]
        public string Open { get; set; }

        [JsonProperty("2. high")]
        public string High { get; set; }

        [JsonProperty("3. low")]
        public string Low { get; set; }

        [JsonProperty("4. close")]
        public string Close { get; set; }

        [JsonProperty("5. volume")]
        public long Volume { get; set; }
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


            Console.WriteLine(data.TimeSeries.Count);
            long sum = 0;
            foreach (DailyData d in data.TimeSeries.GetRange(0, 7))
            {
                sum += d.Volume;
            }
            Console.WriteLine("7 day volume average for " + data.MetaData.Symbol + " is" + sum / 7);

        }

        static public void Main(String[] args)
        {
            QuestionOne();
        }
    }
}