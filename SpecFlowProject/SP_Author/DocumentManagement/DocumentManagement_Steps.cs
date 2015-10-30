using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumProject.Tests;
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

        [Given(@"I select the (.*) Grid Record")]
        [When(@"I select the (.*) Grid Record")]
        [Then(@"I select the (.*) Grid Record")]
        public void WhenISelectAGridRecord(string recordString)
        {

            SupportPoint.DocumentManagementPage.FindGridRecord(recordString);
        }

        [Given(@"the correct folder is selected")]
        [When(@"the correct folder is selected")]
        [Then(@"the correct folder is selected")]
        public void ThenTheCorrectFolderIsSelected()
        {

        }

        [Given(@"I select the (.*) Document Selector Folder")]
        [When(@"I select the (.*) Document Selector Folder")]
        [Then(@"I select the (.*) Document Selector Folder")]
        public void WhenISelectADocumentSelectorFolder(string folderString)
        {
            char[] splitter = { ',' };
            string[] folders = folderString.Split(splitter);
            childFolder = folders[folders.Length - 1];
            SupportPoint.SPManagerFolder.ClickOnFolder("Document Selector", folders);
        }
        
        [Given(@"I click on the Document Save Button")]
        [When(@"I click on the Document Save Button")]
        [Then(@"I click on the Document Save Button")]
        public void ThenIClickOnTheDocumentSaveButton()
        {
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
            SupportPoint.DocumentSelectorPage.clickAddDocumentButton();
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
            //SupportPoint.DocumentManagementPage.SetDocumentName(DocumentName);
            SupportPoint.SPManagerDetailsActionsPage.SetName(DocumentName);
            if (ScenarioContext.Current.ContainsKey("DocumentName"))
            {
                ScenarioContext.Current.Set(DocumentName, "DocumentName");
            }
            else
            {
                ScenarioContext.Current.Add("DocumentName", DocumentName);
            }
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


        [Given(@"I search by (.*) for (.*)")]
        [When(@"I search by (.*) for (.*)")]
        [Then(@"I search by (.*) for (.*)")]
        public void WhenISearchByFindByForSeatchText(String findBy, String searchText)
        {
            ScenarioContext.Current.Add("FindBy", findBy);
            ScenarioContext.Current.Add("SearchBy", searchText);
            SupportPoint.DocumentManagementPage.SelectFindBy(findBy);
            SupportPoint.DocumentManagementPage.SetSearchText(searchText);
            SupportPoint.DocumentManagementPage.ClickSubmitSearchButton();
        }

        [Given(@"I search by (.*) for (.*) in Document Selector")]
        [When(@"I search by (.*) for (.*) in Document Selector")]
        [Then(@"I search by (.*) for (.*) in Document Selector")]
        public void WhenISearchByFindByForSeatchTextInDocumentSelector(String findBy, String searchText)
        {
            ScenarioContext.Current.Add("FindBy", findBy);
            ScenarioContext.Current.Add("SearchBy", searchText);
            SupportPoint.DocumentManagementPage.SelectFindBy(findBy);
            SupportPoint.DocumentManagementPage.SetSearchText(searchText);
            SupportPoint.DocumentManagementPage.ClickSubmitSearchButton();
        }

        [Given(@"the search should return the record by FindBy")]
        [When(@"the search should return the record by FindBy")]
        [Then(@"the search should return the record by FindBy")]
        public void ThenTheSearchShouldReturnTheRecordByFindBy()
        {
            SupportPoint.DocumentManagementPage.ConfirmFoundRecord(ScenarioContext.Current.Get<string>("FindBy"),
               ScenarioContext.Current.Get<string>("SearchBy"));
            

        }

        [Given(@"I verify the Edit button isn't Displayed")]
        [When(@"I verify the Edit button isn't Displayed")]
        [Then(@"I verify the Edit button isn't Displayed")]
        public void ThenIVerifyTheEditButtonIsnTDisplayed()
        {
            SupportPoint.DocumentManagementPage.VerifyButtonNotAvailable();
        }

        [Given(@"I click on the Preview document Button for document (.*)")]
        [When(@"I click on the Preview document Button for document (.*)")]
        [Then(@"I click on the Preview document Button for document (.*)")]
        public void ThenIClickOnThePreviewDocumentButton(string documentTitle)
        {
            SupportPoint.DocumentManagementPage.clickPreviewDocumentButton(documentTitle);
        }

        [Given(@"I confirm the document (.*) is Open")]
        [When(@"I confirm the document (.*) is Open")]
        [Then(@"I confirm the document (.*) is Open")]
        public void ThenIConfirmTheDocumentIsOpen(string documentTitle)
        {
            SupportPoint.DocumentPreviewPage.confirmPreviewBrowserOpen(documentTitle);
        }

        [Given(@"I view readers permission settings")]
        [When(@"I view readers permission settings")]
        [Then(@"I view readers permission settings")]
        public void GivenIViewReadersPermissionSettings()
        {
            SupportPoint.DocumentManagementPage.ConfirmReadersPermissionsViewable();
        }

        [Given(@"I view Writers permission settings")]
        [When(@"I view Writers permission settings")]
        [Then(@"I view Writers permission settings")]
        public void GivenIViewWritersPermissionSettings()
        {
            SupportPoint.DocumentManagementPage.ConfirmWritersPermissionsViewable();
        }

        [Given(@"I view Permissions admin permission settings")]
        [When(@"I view Permissions admin permission settings")]
        [Then(@"I view Permissions admin permission settings")]
        public void GivenIViewPermissionsAdminPermissionSettings()
        {
            SupportPoint.DocumentManagementPage.ConfirmPermissionsAdminPermissionsViewable();
        }

        [Given(@"I make (.*) permission table empty")]
        [When(@"I make (.*) permission table empty")]
        [Then(@"I make (.*) permission table empty")]
        public void GivenIMakePermissionTableEmpty(string tableName)
        {
            SupportPoint.DocumentManagementPage.makePermissionsTableEmpty(tableName);
           
        }

        [Given(@"I confirm folder icon for (.*) is set to (.*)")]
        [When(@"I confirm folder icon for (.*) is set to (.*)")]
        [Then(@"I confirm folder icon for (.*) is set to (.*)")]
        public void GivenIConfirmFolderIconIsSetTo(string folderString, string folderIcon)
        {
            this.WhenISelectADocumentFolder(folderString);
            string folderIconString = SupportPoint.DocumentManagementPage.GetFolderIconTitle();
            StringAssert.Contains(folderIconString, folderIcon, "Folder Icon is not as expected:" + folderIconString);
        }


    }
}
