using SP_Automation.Tests;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class DocumentManagement_CreateDoumentSteps
    {

        [Given(@"I press Details & Actions")]
        [When(@"I press Details & Actions")]
        [Then(@"I press Details & Actions")]
        public void WhenIPressDetailsActions()
        {
            SupportPoint.DetailsActions.DetailsActions();
        }

        [Given(@"I select new")]
        [When(@"I select new")]
        [Then(@"I select new")]
        public void WhenISelectNew()
        {
            SupportPoint.DetailsActions.New();
        }
    }
}
