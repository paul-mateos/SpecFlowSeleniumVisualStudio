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
using Panviva.LiveAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SP_Automation.Rest
{
    /**
     * Low level RestAPI Lib
     */
    public class RestAPI
    {
        private string Address;  //base URL
        private List<KeyValuePair<string, Object>> list = new List<KeyValuePair<string, Object>>();

        private HttpResponseMessage response; //maintaion response msg
        
        public RestAPI(String addr)
        {
            Address = addr;
        }

        public static RestAPI newRequest(string baseAddress)
        {
            return new RestAPI(baseAddress);
        }

        public RestAPI addParam(String key, Object value)
        {
            list.Add(new KeyValuePair<string,Object>(key, value));
            return this;
        }

        public RestAPI addParam(String key, Object value, Object ignoreValue)
        {
            if (value.Equals(ignoreValue)) return this;
            
            return addParam(key, value);
        }

      
        /**
         * build full URL by parameter strings
         */
        protected string Build()
        {
            string rtn = Address;

            foreach(KeyValuePair<string, Object> kv in list)
            {
                rtn += "&" + kv.Key + "=" + kv.Value;
            }

            return rtn;
        }

        public RestAPI Get()
        {
           GetAndVerifyStatus(Build(), HttpStatusCode.OK);
           return this;
        }

 

        public RestAPI Post(Object JsonObj = null)
        {
            PostAndVerifyStatus(Build(), HttpStatusCode.OK, JsonObj);
            return this;
        }

        public RestAPI GetShouldOK(string fullUrl)
       {
           GetAndVerifyStatus(fullUrl, HttpStatusCode.OK);
           return this;
    
       }

        public RestAPI GetAndVerifyStatus(string fullUrl, System.Net.HttpStatusCode code)
       {
           HttpClient client = new HttpClient();
           // Send asynchronous request
           Task.Run(async () =>
           {
               response = await client.GetAsync(fullUrl);

           }).GetAwaiter().GetResult();
            // Check that response was successful or throw exception     
            Assert.AreEqual<System.Net.HttpStatusCode>(code, response.StatusCode);
           
           return this;
       }




        public RestAPI PostAndVerifyStatus(string fullUrl, System.Net.HttpStatusCode code, Object data = null)
       {
           HttpClient client = new HttpClient();
           // Send asynchronous request
           Task.Run(async () =>
           {
               System.Diagnostics.Debug.WriteLine("Post to:" + fullUrl);
               response = await client.PostAsJsonAsync(fullUrl, data);

           }).GetAwaiter().GetResult();
           // Check that response was successful or throw exception
           Assert.AreEqual<System.Net.HttpStatusCode>(code, response.StatusCode);
           return this;
       }



        public RestAPI PutAndVerifyStatus(string fullUrl, System.Net.HttpStatusCode code, Object data = null)
       {
           HttpClient client = new HttpClient();
           // Send asynchronous request
          
           Task.Run(async () =>
           {

               response = await client.PutAsJsonAsync(fullUrl, data);

           }).GetAwaiter().GetResult();
            
            Assert.AreEqual<System.Net.HttpStatusCode>(code, response.StatusCode);
           return this;
       }

        public RestAPI DeleteAndVerifyStatus(string fullUrl, System.Net.HttpStatusCode code)
       {
           HttpClient client = new HttpClient();
           // Send asynchronous request
          
           Task.Run(async () =>
           {
               response = await client.DeleteAsync(fullUrl);

           }).GetAwaiter().GetResult();

           Assert.AreEqual<System.Net.HttpStatusCode>(code, response.StatusCode);

           return this;
       }

        public RestAPI DeleteShouldOK(string fullUrl)
       {
           DeleteAndVerifyStatus(fullUrl, System.Net.HttpStatusCode.OK);
           return this;
       }


 }
   
}
