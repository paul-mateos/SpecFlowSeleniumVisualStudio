using System;
using TechTalk.SpecFlow;
using SP_Automation;
using SP_Automation.Tests;

namespace SpecFlowProject
{
    [Binding]
    public class DocumentManagement_SelectMultipleFoldersSteps
    {
        [Given(@"I press Multiple Selection")]
        [When(@"I press Multiple Selection")]
        [Then(@"I press Multiple Selection")]
        public void WhenIPressMultipleSelection()
        {
            SupportPoint.DocumentManagementPage.clickMultipleSelectionBTN();
        }


    }
}
