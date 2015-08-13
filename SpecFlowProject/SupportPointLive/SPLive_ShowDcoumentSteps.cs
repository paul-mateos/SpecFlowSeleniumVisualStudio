using Newtonsoft.Json;
using Panviva.LiveAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace SpecFlowProject
{
    [Binding]
    public class SPLive_ShowDcoumentSteps
    {
        private String url;
        private Stream streamContent;
        private HttpResponseMessage responseMessage;
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

        // Steps for Call Example API with key Scenario

        [When(@"full URL request executed")]
        public void WhenFullURLRequestExecuted()
        {
            // String fullUrl = ScenarioContext.Current.ge("fullUrl");
            HttpClient client = new HttpClient();
            Task.Run(async () => {
                responseMessage = await client.GetAsync(url);

            }).GetAwaiter().GetResult();
           
        }

        
        [Then(@"recieved response with Invalid User")]
        public void ThenRecievedResponseWithInvalidUser()
        {
            /* StreamReader readStream = new StreamReader(response, Encoding.UTF8);
             String jsonObject = readStream.ReadToEnd();
             Object values = JsonConvert.DeserializeObject(jsonObject);
             JsonTextReader reader = new JsonTextReader(new StringReader(jsonObject));
             while (reader.Read())
             {
                 if (reader.Value != null)
                     Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                 else
                     Console.WriteLine("Token: {0}", reader.TokenType);
             } */

            String status = responseMessage.StatusCode.ToString();
        }


        // Different Scenario Steps


        [When(@"request executed")]
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
            Object values = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonObject);
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
        
        [Then(@"recieved response")]
        public void ThenRecievedResponse()
        {
           
        }
    }
}
