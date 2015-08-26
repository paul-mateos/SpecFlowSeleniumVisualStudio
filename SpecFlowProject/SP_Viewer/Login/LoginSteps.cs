using System;
using System.Threading;
using TechTalk.SpecFlow;
using SP_Automation.Tests;
using SP_Automation.PageModels;

namespace SpecFlowProject
{
    [Binding]
    public class LoginSteps
    {

        //LoginTest test;


        [Given(@"SupportPoint is opened")]
        [When(@"SupportPoint is opened")]
        [Then(@"SupportPoint is opened")]
        public void GivenSupportPointIsOpened()
        {

           SupportPoint.OpenSupportPoint();

        }


        [Given(@"I login as a valid user with login is (.*) and password is (.*)")]
        [When(@"I login as a valid user with login is (.*) and password is (.*)")]
        [Then(@"I login as a valid user with login is (.*) and password is (.*)")]
        public void WhenILoginAsAValidUserWithLoginAndPassword(String username, String password)
        {
            
            if (!SupportPoint.IsSupportPointOpen()) SupportPoint.OpenSupportPoint();
            SupportPoint.LogIn.Login(username, password);

        }


        [Given(@"I should be logged in successfully")]
        [When(@"I should be logged in successfully")]
        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            //yeah, nothing to do here
        }

        [Given(@"I logout")]
        [When(@"I logout")]
        [Then(@"I logout")]
        public void WhenILogout()
        {

            SupportPoint.LogIn.LogOutAndCloseApp();
        }

        //[Then(@"I should be logged out")]
        //public void ThenIShouldBeLoggedout()
        //{
        //    Thread.Sleep(5000);
        //}
    }
}
