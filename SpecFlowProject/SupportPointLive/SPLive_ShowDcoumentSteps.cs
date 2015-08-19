using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Panviva.LiveAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TechTalk.SpecFlow;


namespace SpecFlowProject
{
    [Binding]
    public class SPLive_ShowDcoumentSteps
    {
        private String url;
        private Stream streamContent;
        private HttpResponseMessage responseMessage = null;
        private DocumentRequest docRequest;


        // Steps for Call Example API with key Scenario


        [Given(@"Api call with url ""(.*)""")]
        public void GivenApiCallWithUrl(string url)
        {
            this.url = url;
            docRequest = new DocumentRequest(url);
          
        }

      

        // Steps for Call Example API with key Scenario

        [Given(@"api with ""(.*)"" as ""(.*)"", ""(.*)"" as ""(.*)"", ""(.*)"" as ""(.*)"", ""(.*)"" as ""(.*)"", ""(.*)"" as ""(.*)""")]
        public void GivenApiWithAsAsAsAsAs(string apiKey, string apiKey_value, string name, string nameValue, string format, string formatValue, string bucket, string bucketValue, string limit, string limitValue)
        {
            String fullUrl = this.url + docRequest.buildUrlParam(apiKey, apiKey_value) + docRequest.buildUrlParam(name, nameValue) + docRequest.buildUrlParam(format, formatValue) + docRequest.buildUrlParam(bucket, bucketValue) + docRequest.buildUrlParam(limit, limitValue);
            this.url = fullUrl;
            //ScenarioContext.Current.Add("fullUrl", fullUrl);
        }

        [Given(@"valid api with ""(.*)"" as ""(.*)"", ""(.*)"" as ""(.*)"", ""(.*)"" as ""(.*)""")]
        public void GivenValidApiWithAs(string apiKey, string apiKey_value, string name, string nameValue, string format, string formatValue)
        {
            String fullUrl = this.url + docRequest.buildUrlParam(apiKey, apiKey_value) + docRequest.buildUrlParam(name, nameValue) + docRequest.buildUrlParam(format, formatValue);
            this.url = fullUrl;
        }

        [Given(@"valid area iputs ""(.*)"" as ""(.*)"", ""(.*)"" as ""(.*)""")]
        public void GivenValidAreaIputsAsAs(string near, string nearValue, string auth, string authValue)
        {
            String fullUrl = this.url + docRequest.buildUrlParam(near, nearValue) + docRequest.buildUrlParam(auth, authValue);
            this.url = fullUrl;
        }


        // Steps for Call Example API with key Scenario

        [When(@"full URL request executed")]
         public void WhenFullURLRequestExecuted()
        {
            // String fullUrl = ScenarioContext.Current.ge("fullUrl");
        /*    HttpClient client = new HttpClient();
            Task.Run(async () => {
                responseMessage = await client.GetAsync(url);

            }).GetAwaiter().GetResult();
            */
           
        }

        public void ThenRecievedResponse()
        {
            Stream streamContent = null;
            String status = responseMessage.StatusCode.ToString();
            if (status.Equals("429"))
            { 
            HttpContent content = responseMessage.Content;
            Task.Run(async () =>
            {
                streamContent = await content.ReadAsStreamAsync();

            }).GetAwaiter().GetResult();

            StreamReader readStream = new StreamReader(streamContent, Encoding.UTF8);
            String jsonObject = readStream.ReadToEnd();
            Object values = JsonConvert.DeserializeObject(jsonObject);
            JsonTextReader reader = new JsonTextReader(new StringReader(jsonObject));
            while (reader.Read())
            {
                if (reader.Value != null)
                    Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                else
                    Console.WriteLine("Token: {0}", reader.TokenType);
            }
          }
        }


        // Different Scenario Steps


        
        [Then(@"recieved response with Valid User")]
        [Then(@"recieved response with Invalid User")]
        [Then(@"recieved response")]
        public void WhenRequestExecuted()
        {
            HttpClient client = new HttpClient();
            // Send asynchronous request
            Task.Run(async () => {
                streamContent = await client.GetStreamAsync(url);

            }).GetAwaiter().GetResult();
            // Check that response was successful or throw exception
            StreamReader readStream = new StreamReader(streamContent, Encoding.UTF8);

            String jsonObject = readStream.ReadToEnd();
            
            Object values = JsonConvert.DeserializeObject(jsonObject);
            JObject obj = JObject.Parse(values.ToString());
           // dynamic obj2 = JObject.Parse(values.ToString());
            // IList<string> venues = obj["meta"].Select(t => (string)t).ToList();

            // to get the code value
            string code = (string)obj["meta"]["code"];
           // string code2 = (string)obj2.meta.code;
            // for bad request use HttpMessage status code

            //  Assert.AreEqual<System.Net.HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);
            JsonTextReader reader = new JsonTextReader(new StringReader(jsonObject));
            
            while (reader.Read())
                {
                    if (reader.Value != null)
                          Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                  else
                        Console.WriteLine("Token: {0}", reader.TokenType);
                }
        }

        [Then(@"response status is ""(.*)""")]
        public void ThenResponseStatusIs(string p0)
        {
            
        }
        
      
    }
}
