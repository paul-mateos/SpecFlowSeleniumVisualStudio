using System;
using TechTalk.SpecFlow;
using SP_Automation.Tests;
using SpecFlowProject.SupportPointLive;
using SP_Automation.PageModels;
using SpecFlowProject.SupportPointAPI;


namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public  class DocumentManagement_SelectFolderSteps
    {
        //public string childFolder;
        //[When(@"I select the (.*) DocumentFolder")]
        //public void WhenISelectADocumentFolder(string folderString)
        //{
        //    char[] splitter = { ',' };
        //    string[] folders = folderString.Split(splitter);
        //    childFolder = folders[folders.Length - 1];
        //    SupportPoint.SPManagerFolder.ClickOnFolder("Document", folders);
        //}

        //[Then(@"the correct folder is selected")]
        //public void ThenTheCorrectFolderIsSelected()
        //{
        
        }

        [AfterScenario("@2_DocumentManagement_SelectFolder")]
        public static void AfterScenario()
        {
            SupportPoint.LogIn.CloseSPManager();
            SupportPoint.LogIn.LogOutAndCloseApp();
        }


    }
}
