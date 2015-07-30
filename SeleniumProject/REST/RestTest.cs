using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Panviva.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panviva.Rest
{
    public class RestTest
    {

        public static HttpResponseMessage GetShouldOK(string address)
       {
          return GetAndVerifyStatus(address, HttpStatusCode.OK);
    
       }

       public static HttpResponseMessage GetAndVerifyStatus(string address, System.Net.HttpStatusCode code)
       {
           HttpClient client = new HttpClient();
           // Send asynchronous request
           HttpResponseMessage response = null;
           Task.Run(async () =>
           {
               response = await client.GetAsync(address);

           }).GetAwaiter().GetResult();
           // Check that response was successful or throw exception
           Assert.AreEqual<System.Net.HttpStatusCode>(code, response.StatusCode);
           return response;
       }


       public static HttpResponseMessage PostShouldOK(string address, Object data = null)
       {
           return PostAndVerifyStatus(address, HttpStatusCode.OK);
       }

       public static HttpResponseMessage PostAndVerifyStatus(string address, System.Net.HttpStatusCode code, Object data = null)
       {
           HttpClient client = new HttpClient();
           // Send asynchronous request
           HttpResponseMessage response = null;
           Task.Run(async () =>
           {
               response = await client.PostAsJsonAsync(address, data);

           }).GetAwaiter().GetResult();
           // Check that response was successful or throw exception
           Assert.AreEqual<System.Net.HttpStatusCode>(code, response.StatusCode);
           return response;
       }

       public static HttpResponseMessage PutShouldOK(string address, Object data = null)
       {
           return PutAndVerifyStatus(address, HttpStatusCode.OK, data);
       }

       public static HttpResponseMessage PutAndVerifyStatus(string address, System.Net.HttpStatusCode code, Object data = null)
       {
           HttpClient client = new HttpClient();
           // Send asynchronous request
           HttpResponseMessage response = null;
           Task.Run(async () =>
           {
               response = await client.PutAsJsonAsync(address, data);

           }).GetAwaiter().GetResult();
           
           Assert.AreEqual<System.Net.HttpStatusCode>(code, response.StatusCode);
           return response;
       }

       public static HttpResponseMessage DeleteAndVerifyStatus(string address, System.Net.HttpStatusCode code)
       {
           HttpClient client = new HttpClient();
           // Send asynchronous request
           HttpResponseMessage response = null;
           Task.Run(async () =>
           {
               response = await client.DeleteAsync(address);

           }).GetAwaiter().GetResult();

           Assert.AreEqual<System.Net.HttpStatusCode>(code, response.StatusCode);
           return response;
       }

       public static HttpResponseMessage DeleteShouldOK(string address)
       {
           return DeleteAndVerifyStatus(address, System.Net.HttpStatusCode.OK);
           //Assert.AreEqual<System.Net.HttpStatusCode>(code, response.StatusCode);
       }

       
       
       /*

        public static async Task RunClient()
        {
            // Create an HttpClient instance
            HttpClient client = new HttpClient();

            // Send a request asynchronously and continue when complete
           // HttpResponseMessage response = await client.GetAsync(_address);

           

            DocumentRequest r = new DocumentRequest();
            r.ApiKey = "key  x";

           // HttpResponseMessage response = await client.PostAsJsonAsync(_address + r.genUrlString);
            HttpResponseMessage response = await client.GetAsync("" + r.GenUrlString());
            //client.PostAsJsonAsync();
            
            // Check that response was successful or throw exception
            response.EnsureSuccessStatusCode();

            // Read response asynchronously as JToken and write out top facts for each country
            JArray content =  await response.Content.ReadAsAsync<JArray>();
            
            System.Diagnostics.Debug.WriteLine("First 50 countries listed by The World Bank...");
            foreach (var country in content[1])
            {
                System.Diagnostics.Debug.WriteLine("   {0}, Country Code: {1}, Capital: {2}, Latitude: {3}, Longitude: {4}",
                    country.Value<string>("name"),
                    country.Value<string>("iso2Code"),
                    country.Value<string>("capitalCity"),
                    country.Value<string>("latitude"),
                    country.Value<string>("longitude"));
            }
        }

        */


 }
   
}
