using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Editor
{
    [Binding]
    public sealed class ImageSelector_Steps: Steps
    {

        [Given(@"the Image Selector is opened")]
        [When(@"the Image Selector is opened")]
        [Then(@"the Image Selector is opened")]
        public void TheImageSelectorIsOpened()
        {
            SupportPoint.ImageSelectorPage.ConfirmImageSelector();
            //SupportPoint.waitForPageLoading();
            
        }


        [Given(@"I search for image by (.*) for (.*) in Image Selector")]
        [When(@"I search for image by (.*) for (.*) in Image Selector")]
        [Then(@"I search for image by (.*) for (.*) in Image Selector")]
        public void WhenISearchForImageByFindByForSearchTextInImageSelector(String findBy,
           String searchText)
        {
            ScenarioContext.Current.Add("FindBy", findBy);
            ScenarioContext.Current.Add("SearchBy", searchText);

            SupportPoint.ImageSelectorPage.SelectFindBy(findBy);
            SupportPoint.ImageSelectorPage.SetSearchText(searchText);
            SupportPoint.ImageSelectorPage.ClickSearchButton();

        }


        [Given(@"the search should return the image record in Image Selector")]
        [When(@"the search should return the image record in Image Selector")]
        [Then(@"the search should return the image record in Image Selector")]
        public void ThenTheSearchShouldReturnTheImageRecordInImageSelector()
        {

            SupportPoint.ImageSelectorPage.ConfirmFoundImage(ScenarioContext.Current.Get<string>("FindBy"),
                ScenarioContext.Current.Get<string>("SearchBy"));

        }

        [Given(@"I click on the Insert Button")]
        [When(@"I click on the Insert Button")]
        [Then(@"I click on the Insert Button")]
        public void WhenIClickOnTheInsertButton()
        {
            SupportPoint.ImageSelectorPage.ClickInsertButton();
        }


    }
}
