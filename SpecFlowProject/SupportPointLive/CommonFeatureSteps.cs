using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SP_Automation.API;
using SP_Automation.Facade;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SupportPointLive
{
    [Binding]
    public class CommonFeatureSteps: Steps
    {
        public APICommons apiRequest = new APICommons();
        private string requestBody = "";
       // private string url;
       // private string fullUrl;
        private API api = new API();
        private Stream dataStream;
        private StreamReader reader;       
       
       
        [Given(@"I want to ""(.*)"" a request")]
        public void GivenIWantToARequest(string method)
        {
            api.requestMethod = method;
        }

        [Given(@"My webservice is ""(.*)""")]
        public void GivenMyWebserviceIs(string apiDefinition)
        {
            api.webservice = apiDefinition;
        }

        [Given(@"I have path variables")]
        public void GivenIHavePathVariables(Table table)
        {
            if (table.RowCount != 0)
            {
                foreach (var row in table.Rows)
                {
                    api.addParameters(row["Key"], row["Value"]);
                }
            }
        }
       
      

        [Given(@"I have a request body of")]
        public void GivenIHaveARequestBodyOf(string textBody)
        {
            if (textBody.Contains("SessionID"))
            {
                //Given(@"I have an API for Account Login");
               // Thread.Sleep(5000);
                if (FeatureContext.Current.ContainsKey("SID"))
                {
                    textBody = textBody.Replace(":\"", ":\""+FeatureContext.Current.Get<string>("SID"));
                }

            }
            api.requestBody = api.requestBody + textBody;
        }


        [When(@"I send request")]
        public void WhenISendRequest()
        {
            if (!api.requestBody.Equals(""))
            {
                api.requestBody = "{" + api.requestBody + "}";
            }
            api.SendRequest();
        }

        [Then(@"My result is response")]
        public void ThenMyResultIsResponse()
        {
            try
            { 
                WebResponse response = api.recieveResponse();
                string statusCode = ((HttpWebResponse)response).StatusCode.ToString();
                string status = (((HttpWebResponse)response).StatusDescription).ToString();
                if (statusCode.Equals("OK"))
             {
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                Object values = JsonConvert.DeserializeObject(responseFromServer);
                JObject obj = JObject.Parse(values.ToString());

               
            }
           
        }       catch (WebException ex)
                {
                    HttpWebResponse response = ((HttpWebResponse)ex.Response);
                     Console.WriteLine(response.StatusCode + ex.Message);

                   
                }
            }



        public void GivenRequestBodyAs(string multilineText)
        {
            requestBody = Regex.Replace(multilineText, @"\t|\n|\r", "");
            if (requestBody.Contains("RoleID"))
            {

            }
            if (requestBody.Contains("SID"))
            {
                Given(@"I have an API for Account Login");
                if (FeatureContext.Current.ContainsKey("SID"))
                {
                    requestBody.Replace("SID", FeatureContext.Current.Get<string>("SID"));
                }

            }


        }

        [Given(@"I have an API for Account Login")]
        public void GivenIHaveAnAPIForAccountLogin()
        {
            string SessionID = api.getSessionID("","");
            FeatureContext.Current.Add("SID", SessionID);
            Console.WriteLine("Session ID is retrived Sucessfully");
        }

        [Given(@"I have SessioID with username as ""(.*)"" and password as ""(.*)""")]
        public void GivenIHaveSessioIDWithUsernameAsAndPasswordAs(string userName, string pwd)
        {
            string SessionID = api.getSessionID(userName,pwd);
            FeatureContext.Current.Add("SID", SessionID);
            Console.WriteLine("Session ID is retrived Sucessfully");
        }


    }


}
