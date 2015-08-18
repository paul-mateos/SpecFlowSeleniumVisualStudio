using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class DocumentManagement_CreateDoumentSteps
    {
        [Given(@"I have imported the users/roles file")]
        public void GivenIHaveImportedTheUsersRolesFile()
        {
           //  ScenarioContext.Current.Pending();
        }
        
        [When(@"I press Details & Actions")]
        public void WhenIPressDetailsActions()
        {
          //   ScenarioContext.Current.Pending();
        }
        
        [When(@"I select new")]
        public void WhenISelectNew()
        {
         //   ScenarioContext.Current.Pending();
        }
        
        [When(@"I have entered document (.*), (.*), (.*), (.*) into the fields")]
        public void WhenIHaveEnteredDocumentIntoTheFields(string p0, string p1, string p2, string p3)
        {
            // ScenarioContext.Current.Pending();

            Console.WriteLine("find by" + p0);
            Console.WriteLine("search texgt" + p1);
            Console.WriteLine("search texgt" + p2);
            Console.WriteLine("search texgt" + p3);
        }
        
        [Then(@"the User/Role data is set up")]
        public void ThenTheUserRoleDataIsSetUp()
        {
          //  ScenarioContext.Current.Pending();
        }
        
        [Then(@"SP navigates to the sel_blankFolderName & the folder is expanded")]
        public void ThenSPNavigatesToTheSel_BlankFolderNameTheFolderIsExpanded()
        {
         //   ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be new folders added")]
        public void ThenTheResultShouldBeNewFoldersAdded()
        {
          //  ScenarioContext.Current.Pending();
        }
    }
}
