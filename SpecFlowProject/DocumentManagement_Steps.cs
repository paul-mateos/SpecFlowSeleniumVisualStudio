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
       
        public string childFolder;
        [Given(@"I select the (.*) DocumentFolder")]
        [When(@"I select the (.*) DocumentFolder")]
        [Then(@"I select the (.*) DocumentFolder")]
        public void WhenISelectADocumentFolder(string folderString)
        {
            char[] splitter = { ',' };
            string[] folders = folderString.Split(splitter);
            childFolder = folders[folders.Length - 1];
            SupportPoint.SPManagerFolder.ClickOnFolder("Document", folders);
        }

        [Given(@"the correct folder is selected")]
        [When(@"the correct folder is selected")]
        [Then(@"the correct folder is selected")]
        public void ThenTheCorrectFolderIsSelected()
        {

        }
    }
}
