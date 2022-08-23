using Newtonsoft.Json;
using NPI_Details_Collector.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NPI_Details_Collector.Tools
{
    internal class API
    {
        private const string BASE_URL = @"https://npiregistry.cms.hhs.gov/api/";
        public static HttpClient GetHCPDetails()
        {
            var client = new HttpClient() { BaseAddress = new Uri(BASE_URL) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            return client;
        }
    }
}
