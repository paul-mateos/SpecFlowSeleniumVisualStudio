using System;
using TechTalk.SpecFlow;
using SP_Automation;
using SP_Automation.Tests;

namespace SpecFlowProject
{
    [Binding]
    public class DocumentManagement_SelectMultipleFoldersSteps
    {
        [When(@"I press Multiple Selection")]
        public void WhenIPressMultipleSelection()
        {
            SupportPoint.User.MultipleSelection();
        }
    }
}
