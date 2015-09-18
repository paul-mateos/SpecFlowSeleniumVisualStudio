using SeleniumProject.Tests;
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

    
       

        [When(@"I search by (.*) for (.*)")]
        public void WhenISearchByFindByForSeatchText(String findBy, String searchText)
        {
            FindBy = findBy;
            SearchText = searchText;

            Console.WriteLine("find by" + findBy);
            Console.WriteLine("search text" + searchText);


        }
    

        [Then(@"the search should return the record by FindBy")]
        public void ThenTheSearchShouldReturnTheRecordByFindBy()
        {
           
            SupportPoint.DocumentManagementPage.ConfirmFoundRecord(FindBy, SearchText);
  
        }

       }
}
