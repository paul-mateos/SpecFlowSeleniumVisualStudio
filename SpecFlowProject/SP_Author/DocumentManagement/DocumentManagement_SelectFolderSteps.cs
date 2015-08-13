using System;
using TechTalk.SpecFlow;
using SP_Automation.Tests;

namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public class DocumentManagement_SelectFolderSteps
    {
        [When(@"I select the Home Folder")]
        public void WhenISelectTheHomeFolder()
        {
            SupportPoint.Folder.FolderTree();
        }

        [Then(@"the Home folder is expanded")]
        public void ThenTheHomeFolderIsExpanded()
        {
            
        }
    }
}
