using SP_Automation.Tests;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class DocumentManagement_CreateDoumentSteps
    {

        [When(@"I press Details & Actions")]
        public void WhenIPressDetailsActions()
        {
            SupportPoint.DetailsActions.DetailsActions();
        }

        [When(@"I select new")]
        public void WhenISelectNew()
        {
            SupportPoint.DetailsActions.New();
        }
    }
}
