using System;
using TechTalk.SpecFlow;
using SP_Automation.Tests;

namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public class DocumentManagement_SelectFolderSteps
    {
        public string childFolder;
        [When(@"I select the (.*) Folder")]
        public void WhenISelectAFolder(string folderString)
        {
            char[] splitter = { ',' };
            string[] folders = folderString.Split(splitter);
            childFolder = folders[folders.Length - 1];
            SupportPoint.SPManagerFolder.ClickOnFolder(folders);
            //SupportPoint.Folder.FolderTree(foldername);
        }

        [Then(@"the correct folder is selected")]
        public void ThenTheCorrectFolderIsSelected()
        {
        
        }
    }
}
