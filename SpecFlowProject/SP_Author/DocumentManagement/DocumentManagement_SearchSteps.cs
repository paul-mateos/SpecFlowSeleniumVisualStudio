using SP_Automation.Tests;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;



namespace SpecFlowProject.SP_Author.DocumentManagement
{
    [Binding]
    public class DocumentManagement_SearchSteps
    {
        private string FindBy;
        private string SearchText;

    
        [Given(@"I am at Document Management page")]
        public void GivenIAmAtDocumentManagementPage()
        {
             SupportPoint.IsCurrentBrowser("Document Management : SupportPoint");
            
        }

        [When(@"I search by (.*) for (.*)")]
        public void WhenISearchByFindByForSeatchText(String findBy, String searchText)
        {
            FindBy = findBy;
            SearchText = searchText;

            Console.WriteLine("find by" + findBy);
            Console.WriteLine("search texgt" + searchText);


        }
    

        [Then(@"the search should retun the record by FindBy")]
        public void ThenTheSearchShouldRetunTheRecordByFindBy()
        {
           
            SupportPoint.DocumentManagementPage.ConfirmFoundRecord(FindBy, SearchText);
  
        }

       }
}
