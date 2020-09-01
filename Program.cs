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
        public Dictionary<DateTime, DailyData> TimeSeries { get; set; }
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
        public double Open { get; set; }

        [JsonProperty("2. high")]
        public double High { get; set; }

        [JsonProperty("3. low")]
        public double Low { get; set; }

        [JsonProperty("4. close")]
        public double Close { get; set; }

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
            var ticker = "msft";
            var key = "650CS2ENBH9B4PB1";
            var client = new RestClient("https://www.alphavantage.co/query?");
            var request = new RestRequest(Method.GET);
            request.AddParameter("symbol", ticker);
            request.AddParameter("apikey", key);
            request.AddParameter("function", "TIME_SERIES_DAILY");
            request.AddParameter("outputsize", "compact");
            request.AddParameter("datatype", "json");
            IRestResponse response = client.Execute(request);
            StockData data = JsonConvert.DeserializeObject<StockData>(response.Content);

            DateTime startRange = DateTime.Today.AddDays(-7);
            DateTime endRange = DateTime.Today;
            long sum = 0;
            foreach (var e in data.TimeSeries)
            {
                if(e.Key >= startRange && e.Key <= endRange)
                {
                    Console.WriteLine(e.Value.Volume);
                    sum += (int) e.Value.Volume;
                }
            }
            Console.WriteLine("7 day average volume of " + data.MetaData.Symbol +" " + sum/7);
        }
        public static void QuestionTwo()
        {
            var ticker = "aapl";
            var key = "650CS2ENBH9B4PB1";
            var client = new RestClient("https://www.alphavantage.co/query?");
            var request = new RestRequest(Method.GET);
            request.AddParameter("symbol", ticker);
            request.AddParameter("apikey", key);
            request.AddParameter("function", "TIME_SERIES_DAILY");
            request.AddParameter("outputsize", "full");
            request.AddParameter("datatype", "json");
            IRestResponse response = client.Execute(request);
            StockData data = JsonConvert.DeserializeObject<StockData>(response.Content);

            DateTime startRange = DateTime.Today.AddDays(-183);
            DateTime endRange = DateTime.Today;
            double highest = 0;
            foreach (var e in data.TimeSeries)
            {
                if (e.Key >= startRange && e.Key <= endRange)
                {
                   if(e.Value.Close > highest)
                    {
                        highest = e.Value.Close;
                    }
                }
            }
            Console.WriteLine("Highest closing price of " + data.MetaData.Symbol + " is " + highest);
        }

        static public void Main(String[] args)
        {
            QuestionOne();
            QuestionTwo();
        }
    }
}