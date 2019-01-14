﻿using System;

namespace BDD.SampleApi.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class AssuritySampleWebService
    {
        public async Task<string> GetCatalouge(string categoryParam)
        {
            string response = string.Empty;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //string requestParam = "catalogue=false";

            try
            {
                HttpResponseMessage httpResponseMsg = client.GetAsync(categoryParam).Result;

                if (httpResponseMsg.IsSuccessStatusCode)
                {
                    response = httpResponseMsg.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Response: {response}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                //Console.ReadLine();
                throw new ApplicationException("Failed to get response" + e.Message);
            }

            return response;
        }
    }
}