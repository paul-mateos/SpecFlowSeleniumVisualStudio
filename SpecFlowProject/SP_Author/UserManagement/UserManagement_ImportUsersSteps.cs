using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class UserManagement_ImportUsersSteps
    {
        //[Given(@"I login as a valid user with login panviva and password Burke(.*)")]
        //public void GivenILoginAsAValidUserWithLoginPanvivaAndPasswordBurke(int p0)
        //{
        //    ScenarioContext.Current.Pending();
        //}
        
        [When(@"I press Import user, which contains (.*) and (.*)")]
        public void WhenIPressImportUserWhichContainsAnd(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press Choose File")]
        public void WhenIPressChooseFile()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I select the File")]
        public void WhenISelectTheFile()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be new users added")]
        public void ThenTheResultShouldBeNewUsersAdded()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
