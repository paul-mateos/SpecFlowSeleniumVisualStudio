using SP_Automation.Tests;
using SpecFlowProject.SupportPointAPI;
using SpecFlowProject.SupportPointLive;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class SPLive_CommonSteps
    {
        private CommonFeatureSteps common = new CommonFeatureSteps();
        [Given(@"I have a new User")]
        public void GivenIHaveANewUser()
        { 
            // Role Id id 7 for author
            common.CreateNewUser("pa_auth2", "1", "7");
        }
        
        [Given(@"I have an apiKey")]
        public void GivenIHaveAnApiKey()
        {
            common.CreateNewAPIKey();
            common.GetAPIKeyForUser();
        }

        [Given(@"I have logged into SupportPoint")]
        public void GivenIHaveLoggedIntoSupportPoint()
        {

            if (!SupportPoint.IsSupportPointOpen()) SupportPoint.OpenSupportPoint();
            SupportPoint.LogIn.Login(FeatureContext.Current.Get<string>("UserName"), FeatureContext.Current.Get<string>("Pwd"));

        }

        [Then(@"waitForResponse")]
        public void ThenWaitForResponse()
        {
            Thread.Sleep(8000);
        }


    }
}
