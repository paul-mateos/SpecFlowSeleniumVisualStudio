using SP_Automation.API;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SupportPointLive
{
    [Binding]
    public class AccountLoginAPISteps
    {
        private string SessionID;
        private APICommons api = new APICommons();

        [Given(@"I have an API for Account Login")]
        public void GivenIHaveAnAPIForAccountLogin()
        {
           SessionID =  api.getSessionID();
            FeatureContext.Current.Add("SID", SessionID);
            Console.WriteLine("Session ID is retrived Sucessfully");
        }
        
        [Then(@"the result is SessionID")]
        public void ThenTheResultIsSessionID()
        {
            Console.WriteLine("Session ID is retrived Sucessfully");
        }
    }
}
