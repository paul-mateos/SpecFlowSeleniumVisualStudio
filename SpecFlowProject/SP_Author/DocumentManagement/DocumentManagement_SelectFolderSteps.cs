using System;
using TechTalk.SpecFlow;
using SP_Automation.Tests;

namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public class DocumentManagement_SelectFolderSteps
    {
        [When(@"I select the (.*) Folder")]
        public void WhenISelectAFolder(string foldername)
        {
            SupportPoint.Folder.FolderTree(foldername);
        }

        [Then(@"the Home folder is expanded")]
        public void ThenTheHomeFolderIsExpanded()
        {
        // ScenarioContext.Current.Pending();
        }
    }
}
