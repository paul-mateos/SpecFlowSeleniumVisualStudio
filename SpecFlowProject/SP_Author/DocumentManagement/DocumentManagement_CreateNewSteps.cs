using SeleniumProject.Tests;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public class DocumentManagement_CreateNewSteps
    {
        //Shared bindings
        DocumentManagement_Steps _DocumentManagement_Steps = new DocumentManagement_Steps();
        SP_Author_Steps _SP_Author_Steps = new SP_Author_Steps();

        [Given(@"I have selected (.*)")]
        [When(@"I have selected (.*)")]
        [Then(@"I have selected (.*)")]
        public void WhenIHaveSelectedFolder(string newtype)
        {
            SupportPoint.DocumentManagmentNewPage.clickFolder(newtype);
        }

        [Given(@"I have entered Type (.*) Name (.*) Description (.*)")]
        [When(@"I have entered Type (.*) Name (.*) Description (.*)")]
        [Then(@"I have entered Type (.*) Name (.*) Description (.*)")]
        public void IHaveEnteredTypeNameDescription(string type, string name, string description)
        {
            SupportPoint.DocumentManagmentNewPage.fillIn(type, name, description);
        }

        [Given(@"I have entered (.*) Type")]
        [When(@"I have entered (.*) Type")]
        [Then(@"I have entered (.*) Type")]
        public void IHaveEnteredType(string type)
        {
            SupportPoint.DocumentManagmentNewPage.SetType(type);
        }

        [Given(@"I have created a new document with Type (.*) Name (.*) Description (.*)")]
        [When(@"I have created a new document with Type (.*) Name (.*) Description (.*)")]
        [Then(@"I have created a new document with Type (.*) Name (.*) Description (.*)")]
        public void IHaveCreatedDocumentTypeNameDescription(string type, string name, string description)
        {
            _DocumentManagement_Steps.WhenISelectADocumentFolder("Home");
            _SP_Author_Steps.WhenIPressDetailsActions();
            _SP_Author_Steps.WhenISelectFromDetailsAndActions("New");
            WhenIHaveSelectedFolder("Document");
            SupportPoint.DocumentManagmentNewPage.fillIn(type, name, description);
            _SP_Author_Steps.ThenIClickOnTheSaveButton();
        }
    }
}
