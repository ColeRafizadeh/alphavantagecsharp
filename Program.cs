﻿using System;
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
            public Decimal Open { get; set; }
            public Decimal High { get; set; }
            public Decimal Low { get; set; }
            public Decimal Close { get; set; }
            public Decimal Volume { get; set; }
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
