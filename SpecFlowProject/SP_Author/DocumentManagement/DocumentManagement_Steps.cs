using SP_Automation.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public sealed class DocumentManagement_Steps
    {
        [Given(@"I click on the Document Save Button")]
        [When(@"I click on the Document Save Button")]
        [Then(@"I click on the Document Save Button")]
        public void ThenIClickOnTheDocumentSaveButton()
        {
            //SupportPoint.DocumentManagementPage.ClickSaveButton();
            SupportPoint.SPAuthorPage.ClickSaveButton();
        }

        [Given(@"I select the record (.*) using column (.*) from the Document Selector table")]
        [When(@"I select the record (.*) using column (.*) from the Document Selector table")]
        [Then(@"I select the record (.*) using column (.*) from the Document Selector table")]
        public void IselecttherecordfromtheDocumentSelectortable(string searchValue, string colName)
        {
            SupportPoint.DocumentManagementPage.ClickSelectorRecord(colName, searchValue);
                
        }

        

        [Given(@"I select the record (.*) using column (.*) from the Document table")]
        [When(@"I select the record (.*) using column (.*) from the Document table")]
        [Then(@"I select the record (.*) using column (.*) from the Document table")]
        public void IselecttherecordfromtheDocumenttable(string searchValue, string colName)
        {
            SupportPoint.DocumentManagementPage.ClickRecord(colName, searchValue);

        }

        [Given(@"I click on the Add document Button")]
        [When(@"I click on the Add document Button")]
        [Then(@"I click on the Add document Button")]
        public void ThenIClickOnTheAdddocumentButton()
        {
            SupportPoint.DocumentManagementPage.clickAddDocumentButton();
        }

        [Given(@"I click on the Add folder Button")]
        [When(@"I click on the Add folder Button")]
        [Then(@"I click on the Add folder Button")]
        public void ThenIClickOnTheAddfolderButton()
        {
            SupportPoint.DocumentManagementPage.clickAddFolderButton();
        }

        [Given(@"I click on the Apply selection Button")]
        [When(@"I click on the Apply selection Button")]
        [Then(@"I click on the Apply selection Button")]
        public void ThenIClickOnTheApplyselectionButton()
        {
            SupportPoint.DocumentManagementPage.clickApplySelectionButton();
        }

        [Given(@"I enter the Document Name (.*)")]
        [When(@"I enter the Document Name (.*)")]
        [Then(@"I enter the Document Name (.*)")]
        public void WhenIEnterTheDocumentNameNewName(string DocumentName)
        {
            SupportPoint.DocumentManagementPage.SetDocumentName(DocumentName);
            FeatureContext.Current.Add("DocumentName", DocumentName);
        }

        [Given(@"I Click on the Document Move Button")]
        [When(@"I Click on the Document Move Button")]
        [Then(@"I Click on the Document Move Button")]
        public void WhenIClickOnTheDocumentMoveButton()
        {
            SupportPoint.DocumentManagementPage.ClickMoveButton();
        }

        [Given(@"I Click on the Document Move into Button")]
        [When(@"I Click on the Document Move into Button")]
        [Then(@"I Click on the Document Move into Button")]
        public void WhenIClickOnTheDocumentMoveintoButton()
        {
            SupportPoint.DocumentManagementPage.ClickMoveintoButton();
        }
    }
}
