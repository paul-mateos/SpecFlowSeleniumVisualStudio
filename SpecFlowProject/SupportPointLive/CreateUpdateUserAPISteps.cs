using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SP_Automation.API;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SupportPointLive
{
    [Binding]
    public class CreateUpdateUserAPISteps
    {
        private APICommons api;
        private string requestBody;
        private string url;
        [Given(@"an API to create user ""(.*)""")]
        public void GivenAnAPIToCreateUser(string url)
        {
            this.url = url;
        }
        
        [Given(@"request body as")]
        public void GivenRequestBodyAs(string multilineText)
        {
            string replacement = Regex.Replace(multilineText, @"\t|\n|\r", "");
            Object values = JsonConvert.SerializeObject(replacement);
            //JObject obj = JObject.Parse(values.ToString());
           
        }
        
        [When(@"request executed")]
        public void WhenRequestExecuted()
        {
            api.sendPOSTRequest(url, requestBody);
        }
        
        [Then(@"newuser created with response status as ""(.*)""")]
        public void ThenNewuserCreatedWithResponseStatusAs(string p0)
        {
            api.getUserImportResponse();
            
        }
    }
}
