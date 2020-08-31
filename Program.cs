using System;
using ServiceStack.Text;
using RestSharp;

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
            string key = "";
            var client = new RestClient("https://www.alphavantage.co/query?");
            var request = new RestRequest(Method.GET);
            request.AddParameter("symbol", "MSFT");
            request.AddParameter("apikey", key);
            request.AddParameter("function", "TIME_SERIES_DAILY");
            request.AddParameter("outputsize", "compact");
            request.AddParameter("datatype", "csv");
            IRestResponse response = client.Execute(request);

            var timeseries = CsvSerializer
            Console.WriteLine("Begin");
            Console.WriteLine(response.Content);
            

        }

        static public void Main(String[] args)
        {
            QuestionOne();
        }
    }
}
