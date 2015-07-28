using System;
using System.Threading;
using TechTalk.SpecFlow;
using SP_Automation.Tests;
using SP_Automation.PageModels;

namespace SpecFlow_SupportPoint
{
    [Binding]
    public class FolderNavSteps
    {

        BaseTest test;
     

        [Given(@"I logged in as (.*) user")]
        public void GivenLoginAsUser(string type)
        {

            test = new LoginTest();
            test.Initialize();
            ((LoginTest)test).initBrowser();

            if (type.Equals("advanced"))
            {
                ((LoginTest)test).SuccessfulLogin("panviva", "Burke6368");
            }
            else if (type.Equals("configurator"))
            {
                ((LoginTest)test).SuccessfulLogin("Config", "Config");
            }
            else
            {
                ((LoginTest)test).SuccessfulLogin("aa", "aa");
            }
              
        }

        [When(@"I navigate to Folders")]
        public void WhenINavigateToFolders()
        {
            test = new FolderNavTest().setPrevTest(test);
            ((FolderNavTest)test).navToFolder();
     
        }

        [Then(@"I should see folder view")]
        public void ThenIShouldSeeFolderView()
        {
            ((FolderNavTest)test).verifyFolderExist();
            Thread.Sleep(5000);
            test.TestCleanUp();
            Thread.Sleep(5000);
        }
    }
}
