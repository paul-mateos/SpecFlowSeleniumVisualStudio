using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Editor
{
    [Binding]
    public sealed class ImageMapping_Steps: Steps
    {

        [Given(@"the Image Mapping is opened")]
        [When(@"the Image Mapping is opened")]
        [Then(@"the Image Mapping is opened")]
        public void TheImageMappingIsOpened()
        {
            SupportPoint.ImageMappingPage.ConfirmImageMapping();
            //SupportPoint.waitForPageLoading();
            
        }



        [Given(@"I click on the Image Mapping Save Button")]
        [When(@"I click on the Image Mapping Save Button")]
        [Then(@"I click on the Image Mapping Save Button")]
        public void IClickOnTheImageMappingSaveButton()
        {
            SupportPoint.ImageMappingPage.ClickSaveButton();
        }


    }
}
