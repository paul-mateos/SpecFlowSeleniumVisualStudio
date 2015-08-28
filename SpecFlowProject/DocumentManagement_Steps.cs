using SP_Automation.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class DocumentManagement
    {
        
        //[Given(@"I am at Document Management page")]
        //public void GivenIAmAtDocumentManagementPage()
        //{
        //    SupportPoint.IsCurrentBrowser("Document Management : SupportPoint");

        //}

        public string childFolder;
        [When(@"I select the (.*) DocumentFolder")]
        public void WhenISelectADocumentFolder(string folderString)
        {
            char[] splitter = { ',' };
            string[] folders = folderString.Split(splitter);
            childFolder = folders[folders.Length - 1];
            SupportPoint.SPManagerFolder.ClickOnFolder("Document", folders);
        }

        [Then(@"the correct folder is selected")]
        public void ThenTheCorrectFolderIsSelected()
        {

        }
    }
}
