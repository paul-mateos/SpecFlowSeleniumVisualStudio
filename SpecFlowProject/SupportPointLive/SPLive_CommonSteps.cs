using SP_Automation.Tests;
using SpecFlowProject.SupportPointAPI;
using SpecFlowProject.SupportPointLive;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class SPLive_CommonSteps:Steps
    {
       // private CommonFeatureSteps common = new CommonFeatureSteps();
        
        [Given(@"I have logged into SupportPoint")]
        public void GivenIHaveLoggedIntoSupportPoint()
        {

            if (!SupportPoint.IsSupportPointOpen()) SupportPoint.OpenSupportPoint();
            SupportPoint.LogIn.Login(FeatureContext.Current.Get<string>("UserName"), FeatureContext.Current.Get<string>("Pwd"));

        }

        [When(@"waitBeforeRequest")]
        [Then(@"waitForResponse")]
        public void ThenWaitForResponse()
        {
            Thread.Sleep(8000);
        }


    }
}
