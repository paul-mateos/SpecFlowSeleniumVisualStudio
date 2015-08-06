using System;
using System.Threading;
using TechTalk.SpecFlow;
using SP_Automation.Tests;
using SP_Automation.PageModels;

namespace SpecFlow_SupportPoint
{
    [Binding]
    public class LoginSteps
    {

        LoginTest test;


        [Given(@"Support Portal is opened")]
        [When(@"Support Portal is opened")]
        public void GivenSupportPortalIsOpened()
        {
         //   System.Diagnostics.Debug.WriteLine("GivenSupportPortalIsOpened");
            
            /*
            test = new LoginTest();
            test.Initialize();
            test.initBrowser();
            */

           SupportPoint.OpenSupportPoint();

        }

        [Given(@"I login as a valid user with login is (.*) and password is (.*)")]
        [When(@"I login as a valid user with login is (.*) and password is (.*)")]
        public void WhenILoginAsAValidUserWithLoginIsPanvivaAndPasswordIsBurke(String username, String password)
        {
            
            System.Diagnostics.Debug.WriteLine("WhenILoginAsAValidUserWithLoginIsPanvivaAndPasswordIsBurke:" + username + " pss=" + password);
            if (!SupportPoint.IsSupportPointOpen()) SupportPoint.OpenSupportPoint();
            SupportPoint.LogIn.Login(username, password);

        }


        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            //yeah, nothing to do here
        }

        [When(@"I logout")]
        public void WhenILogout()
        {

           SupportPoint.LogIn.LogOut();
        }

        [Then(@"I should be logged out")]
        public void ThenIShouldBeLoggedout()
        {
            Thread.Sleep(5000);
        }
    }
}
