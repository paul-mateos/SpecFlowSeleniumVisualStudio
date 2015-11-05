using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author
{
    [Binding]
    public sealed class DocumentSelector_Steps: Steps
    {

        public string childFolder;

        [Given(@"the Document Selector is opened")]
        [When(@"the Document Selector is opened")]
        [Then(@"the Document Selector is opened")]
        public void TheDocumentSelectorIsOpened()
        {
            SupportPoint.DocumentSelectorPage.ConfirmDocumentSelector();
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


        [Given(@"I select the record (.*) using column (.*) from the Document Selector table")]
        [When(@"I select the record (.*) using column (.*) from the Document Selector table")]
        [Then(@"I select the record (.*) using column (.*) from the Document Selector table")]
        public void IselecttherecordfromtheDocumentSelectortable(string searchValue, string colName)
        {
            SupportPoint.DocumentSelectorPage.ClickSelectorRecord(colName, searchValue);

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

        [Given(@"I click on the Add document Button")]
        [When(@"I click on the Add document Button")]
        [Then(@"I click on the Add document Button")]
        public void ThenIClickOnTheAdddocumentButton()
        {
            SupportPoint.DocumentSelectorPage.clickAddDocumentButton();
        }


    }
}
