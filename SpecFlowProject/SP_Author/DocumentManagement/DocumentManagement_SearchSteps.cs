using SP_Automation.Tests;
using System;
using TechTalk.SpecFlow;



namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public class DocumentManagement_SearchSteps
    {
        private string SearchText;

        [Given(@"I am at Document Management page")]
        public void GivenIAmAtDocumentManagementPage()
        {
             SupportPoint.IsCurrentBrowser("Document Management : SupportPoint");
            
        }

        [When(@"I search by (.*) for (.*)")]
        public void WhenISearchByFindByForSeatchText(String findBy, String searchText)
        {
            //ScenarioContext.Current.Pending();
            ////SupportPoint.SPManagerFind.SearchByFor(findBy, searchText);
            SearchText = searchText;


        }

       
        [Then(@"the search should retun the record by name")]
        public void ThenTheSearchShouldRetunTheRecordByName()
        {
            //Get search result table
            SupportPoint.DocumentManagementPage.ConfirmFoundRecord(SearchText);
            //Check that there is 1 record returned
            //confirm that the name is present on the record
            //SupportPoint.DocumentManagementPage.
        }

    }
}
