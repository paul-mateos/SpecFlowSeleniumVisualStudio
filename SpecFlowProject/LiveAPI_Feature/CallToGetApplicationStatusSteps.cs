using SP_Automation.Rest;
using System;
using System.IO;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading;

namespace SpecFlowProject.LiveAPI_Feature
{
    [Binding]
    public class CallToGetApplicationStatusSteps
    {
       static public String url;
        private Stream response;
        private Object parsedObject;
        [Given(@"I have called webservice ""(.*)""")]
        public void GivenIHaveCalledWebservice(string p0)
        {
            url = p0;
        }

        [Given(@"request type ""(.*)"", Method ""(.*)"" and Description ""(.*)""")]
        public void GivenRequestTypeMethodAndDescription(string p0, string p1, string p2)
        {
           
        }

        [Given(@"request body")]
        public void GivenRequestBody(string multilineText)
        {
            
        }

        [When(@"the request is executed")]
        public void WhenTheRequestIsExecuted()
        {


        }

        [When(@"I executed")]
        public void WhenIExecuted()
        {
            HttpClient client = new HttpClient();
            // Send asynchronous request
            Task.Run(async () =>
            {
                response = await client.GetStreamAsync(url);

            }).GetAwaiter().GetResult();

            Thread.Sleep(5000);
            StreamReader readStream = new StreamReader(response, Encoding.UTF8);
            String jsonObject = readStream.ReadToEnd();
            //  Assert.AreEqual<System.Net.HttpStatusCode>(HttpStatusCode.OK, response.StatusCode);
            //String value = JsonConvert.SerializeObject(jsonObject);
            JsonTextReader reader = new JsonTextReader(new StringReader(jsonObject));
            
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    Debug.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                    //parsedObject = reader.Value;
                }
                else
                    Debug.WriteLine("Token: {0}", reader.TokenType);
            }

        }

        [Then(@"response is recieved")]
        public void ThenResponseIsRecieved()
        {
           
        }

        [Given(@"a API definition ""(.*)""")]
        public void GivenAAPIDefinition(string p0)
        {
           
        }
    }
}
public class MyObject
{
    public string status { get; set; }
    public string Text { get; set; }
 
}