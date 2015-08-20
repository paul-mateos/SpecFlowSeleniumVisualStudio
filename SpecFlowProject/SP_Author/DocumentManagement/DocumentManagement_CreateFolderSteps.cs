using SP_Automation.Tests;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public class DocumentManagement_CreateFolderSteps
    {
        //[When(@"I select (.*) Folder")]
        //public void WhenISelectHomeFolder(String foldername)
        //{
        //    SupportPoint.Folder.FolderTree();
        //    System.Threading.Thread.Sleep(5000);
        //}

        [When(@"I have selected Folder")]
        public void WhenIHaveSelectedFolder()
        {
            SupportPoint.DocumentManagmentNew.clickFolder();
        }

        [When(@"I have entered (.*) (.*) (.*)")]
        public void WhenIHaveEnteredSel_BlankFolderNameSel_BlankFolderDescriptionName(string folderType, string folderName, string folderDescription)
        {
        SupportPoint.DocumentManagmentNew.fillIn(folderType, folderName, folderDescription);
        }
    }
}
