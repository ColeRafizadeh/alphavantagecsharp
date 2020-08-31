using System;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace rest
{

    class Program
    {
        public class AVData
        {
            public DateTime time { get; set; }
            public DateTime Open { get; set; }
            public DateTime High { get; set; }
            public DateTime Low { get; set; }
            public DateTime Close { get; set; }
            public DateTime Volume { get; set; }
        }
        public static void QuestionOne()
        {
            string key = "650CS2ENBH9B4PB1";
            var client = new RestClient("https://www.alphavantage.co/query?");
            var request = new RestRequest(Method.GET);
            request.AddParameter("symbol", "MSFT");
            request.AddParameter("apikey", key);
            request.AddParameter("function", "TIME_SERIES_DAILY");
            request.AddParameter("outputsize", "compact");
            IRestResponse response = client.Execute(request);

            //test
            

        }

        static public void Main(String[] args)
        {
            QuestionOne();
        }
    }
}
