using SP_Automation.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.ImageManagement
{
    [Binding]
    public sealed class ImageManagement_Steps
    {
        public string FindBy;
        public string SearchText;

        [When(@"I search for image by (.*) for (.*)")]
        [Then(@"I search for image by (.*) for (.*)")]
        public void WhenISearchForImageByFindByForSeatchText(String findBy, String searchText)
        {
            FindBy = findBy;
            SearchText = searchText;
            SupportPoint.ImageManagementPage.SelectFindBy(findBy);
            SupportPoint.ImageManagementPage.SetSearchText(searchText);
            SupportPoint.ImageManagementPage.ClickSubmitSearchButton();


        }

        [Then(@"the search should return the image record")]
        public void ThenTheSearchShouldReturnTheImageRecord()
        {
            SupportPoint.ImageManagementPage.ConfirmFoundImage(FindBy, SearchText);
            
        }

    }
}
