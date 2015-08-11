using SP_Automation.Tests;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public class DocumentManagement_SearchSteps
    {
        [Given(@"I am at Document Management page")]
        public void GivenIAmAtDocumentManagementPage()
        {
             SupportPoint.IsCurrentBrowser("Document Management : SupportPoint");
            
        }

        [When(@"I search by (.*) for (.*)")]
        public void WhenISearchByFindByForSeatchText(String findBy, String searchText)
        {
            SupportPoint.SPManagerFind.SearchByFor(findBy, searchText);

        }

       
        [Then(@"the search should retun the record by name")]
        public void ThenTheSearchShouldRetunTheRecordByName()
        {
            //SupportPoint.DocumentManagementPage.
        }

    }
}
