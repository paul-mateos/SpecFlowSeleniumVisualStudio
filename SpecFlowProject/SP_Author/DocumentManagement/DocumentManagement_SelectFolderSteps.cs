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
        public string childFolder;

        [BeforeFeature("DocumentManagement_SelectFolder")]
        public static  void BeforeFeature()
        {
            CommonFeatureSteps common = new CommonFeatureSteps();
            // Role Id id 7 for author
            common.CreateNewUser("pa_auth1","1", "7");
           
        }

             
        [When(@"I select the (.*) Folder")]
        public void WhenISelectAFolder(string folderString)
        {
            char[] splitter = { ',' };
            string[] folders = folderString.Split(splitter);
            childFolder = folders[folders.Length - 1];
            SupportPoint.SPManagerFolder.ClickOnFolder(folders);
        }

        [Then(@"the correct folder is selected")]
        public void ThenTheCorrectFolderIsSelected()
        {
        
        }

        [AfterScenario("@2_DocumentManagement_SelectFolder")]
        public static void AfterScenario()
        {
            SupportPoint.LogIn.CloseSPManager();
            SupportPoint.LogIn.LogOutAndCloseApp();
        }


    }
}
