using System;
using System.Threading;
using TechTalk.SpecFlow;
using SeleniumProject.Tests;
using SeleniumProject.PageModels;
using SpecFlowProject.SupportPointAPI;

namespace SpecFlowProject
{
    [Binding]
    public class LoginSteps
    {
      
        [BeforeScenario]
        [Given(@"SupportPoint is opened")]
        [When(@"SupportPoint is opened")]
        [Then(@"SupportPoint is opened")]
        public void GivenSupportPointIsOpened()
        {
            bool tagFound = false;
            Array Tags = ScenarioContext.Current.ScenarioInfo.Tags;
            foreach (string tag in Tags)
            {
                if (tag == "API_Tests")
                {
                    tagFound = true;
                    break;
                }
            }
            if (tagFound == false)
            {
                SupportPoint.OpenSupportPoint();
            }

        }


        [Given(@"I login as a valid user with login is (.*) and password is (.*)")]
        [When(@"I login as a valid user with login is (.*) and password is (.*)")]
        [Then(@"I login as a valid user with login is (.*) and password is (.*)")]
        public void WhenILoginAsAValidUserWithLoginAndPassword(String username, String password)
        {
                        
            if (!SupportPoint.IsSupportPointOpen()) SupportPoint.OpenSupportPoint();
            SupportPoint.LogIn.Login(username, password);

        }
   

        [AfterScenario]
        [Given(@"I Close SupportPoint")]
        [When(@"I Close SupportPoint")]
        [Then(@"I Close SupportPoint")]
        public void ICloseSupportPoint()
        {
            bool tagFound = false;
            Array Tags = ScenarioContext.Current.ScenarioInfo.Tags;
            foreach(string tag in Tags)
            {
                if (tag == "API_Tests")
                {
                    tagFound = true;
                }
            }

            if (tagFound == false)
            {
                CommonFeatureSteps common = new CommonFeatureSteps();
                SupportPoint.ExitSuportPoint();
                common.ThenDeleteUser();
            }
            
        }

    }
}
