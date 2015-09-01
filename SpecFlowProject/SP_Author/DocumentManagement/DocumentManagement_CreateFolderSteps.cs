﻿using SP_Automation.Tests;
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

        [Given(@"I have selected (.*)")]
        [When(@"I have selected (.*)")]
        [Then(@"I have selected (.*)")]
        public void WhenIHaveSelectedFolder(string newtype)
        {
            SupportPoint.DocumentManagmentNew.clickFolder(newtype);
        }

        [When(@"I have entered Type (.*) Name (.*) Description (.*)")]
        public void WhenIHaveEnteredLocalisationSel_BlankFolderNameSel_BlankFolderDescription(string type, string name, string description)
        {
            SupportPoint.DocumentManagmentNew.fillIn(type, name, description);
        }
    }
}
