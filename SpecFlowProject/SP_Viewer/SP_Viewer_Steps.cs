using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Viewer
{
    [Binding]
    public sealed class SP_Viewer_Steps
    {
        public string childFolder;

        [Given(@"I am at Viewer Home")]
        [When(@"I am at Viewer Home")]
        [Then(@"I am at Viewer Home")]
        public void IAmAtTheViewerHomePage()
        {
            SupportPoint.IsCurrentBrowser("Home");
            
        }

        [Given(@"I Open SP Manager to (.*)")]
        [When(@"I Open SP Manager to (.*)")]
        [Then(@"I Open SP Manager to (.*)")]
        public void ThenIOpenSPManager(string managementPage)
        {
            SupportPoint.Nav.ToSupportPointManager(managementPage);
            SupportPoint.waitForPageLoading();
        }

        [Given(@"I click on the Viewer folder Button")]
        [When(@"I click on the Viewer folder Button")]
        [Then(@"I click on the Viewer folder Button")]
        public void IClickOnTheViewerFolderButton()
        {
            SupportPoint.HomePage.ClickFolderNavButton();
        }

        [Given(@"I select the (.*) Viewer Document Folder/File")]
        [When(@"I select the (.*) Viewer Document Folder/File")]
        [Then(@"I select the (.*) Viewer Document Folder/File")]
        public void ISelectAViewerDocumentFolderFile(string folderString)
        {
            char[] splitter = { ',' };
            string[] folders = folderString.Split(splitter);
            childFolder = folders[folders.Length - 1];
            SupportPoint.FolderPage.ClickOnFolder("Viewer", folders);
            SupportPoint.waitForAjaxLoading();
        }

        [Given(@"I click on the Copy Cancel Button")]
        [When(@"I click on the Copy Cancel Button")]
        [Then(@"I click on the Copy Cancel Button")]
        public void IClickOnTheCopyCancelButton()
        {
            SupportPoint.CopyPage.clickCancel();
        }

        [Given(@"I click on the Copy Location Cancel Button")]
        [When(@"I click on the Copy Location Cancel Button")]
        [Then(@"I click on the Copy Location Cancel Button")]
        public void IClickOnTheCopyLocationCancelButton()
        {
            SupportPoint.HomePage.clickCancel();
        }
    }
}
