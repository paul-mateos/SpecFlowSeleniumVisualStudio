using System;
using System.IO;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.LiveAPI_Feature
{
    [Binding]
    public class SwaggerPetstore_PetsSteps
    {
        [Given(@"a ""(.*)"" API definition at ""(.*)""")]
        public void GivenAAPIDefinitionAt(string p0, string p1)
        {

            ScenarioContext.Current.Add("url", p1);
            String url = p1;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // Set some reasonable limits on resources used by this request
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            // Set credentials to use for this request.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine("Content length is {0}", response.ContentLength);
            Console.WriteLine("Content type is {0}", response.ContentType);

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            Console.WriteLine("Response stream received.");
            Console.WriteLine(readStream.ReadToEnd());
            response.Close();
            readStream.Close();

        }
        
        [Given(@"an operation with Id ""(.*)""")]
        public void GivenAnOperationWithId(string p0)
        {
            
        }
        
        [Given(@"request body")]
        public void GivenRequestBody(string multilineText)
        {
            
        }
        
        [Given(@"request type ""(.*)""")]
        public void GivenRequestType(string p0)
        {
           
        }
        
        [When(@"the request is executed")]
        public void WhenTheRequestIsExecuted()
        {
           
        }
        
        [Then(@"response status is ""(.*)""")]
        public void ThenResponseStatusIs(string p0)
        {
           
        }
    }
}
