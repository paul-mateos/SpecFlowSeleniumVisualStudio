using System;
using TechTalk.SpecFlow;
//using Panviva.LiveAPI;
using SP_Automation.Tests;
using SP_Automation;

namespace SpecFlowProject.LiveAPI_Feature
{
    [Binding]
    public class CreateNewUserSteps
    {
        //[Given(@"I have logged into SP, as username (.*) and password (.*)")]
        //public void GivenIHaveLoggedIntoSPAsUsernamePanvivaAndPasswordBurke(string username, string password)
        //{
        //    SupportPoint.OpenSupportPoint();
        //    SupportPoint.LogIn.Login(username, password);
        //}

      
        //[Given(@"I am at User Management page")]
        //public void GivenIAmAtUserManagementPage()
        //{
        //    SupportPoint.Nav.ToSupportPointManager();
        //    //  
        //    SupportPoint.SwitchToSPManager();
        //    System.Threading.Thread.Sleep(5000);
        //    SupportPoint.SPManagerNav.ClickUsers();
        //}
        
       
        [When(@"I press Action")]
        public void WhenIPressAction()
        {
            SupportPoint.User.ClickAction();

        }

        [When(@"I press New User")]
        public void WhenIPressNewUser()
        {
            SupportPoint.User.ClickNewUser();
        }


        [When(@"I have entered (.*), (.*), (.*), (.*), (.*), (.*) into the username, firstname, lastname, email, password, verify password")]
        public void WhenIHaveEnteredAdvAuthorAdvAuthorTestPanviva_ComPasswordPasswordIntoTheUsernameFirstnameLastnameEmailPasswordVerifyPassword(string name, string firstname, string lastname, string email, string password, string verifypassword)
        {
            SupportPoint.User.CreateNewUser(name, firstname, lastname, email, password, verifypassword);
            ScenarioContext.Current.Add("username", name);
        }

        [When(@"I press Save")]
        public void WhenIPressSave()
        {
            SupportPoint.User.Save();
        }
        

        [Then(@"the result should be new user added")]
        public void ThenTheResultShouldBeNewUserAdded()
        {
            string username = ScenarioContext.Current.Get<string>("username");
            // SupportPoint.User.VerifyUserExist();
        }
    }
}
