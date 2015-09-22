using SeleniumProject.Tests;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class Administration_SearchSetupSteps
    {
        [Given(@"I enter the following search weighing: (.*), (.*), (.*), (.*), (.*)")]
        [Then(@"I enter the following search weighing: (.*), (.*), (.*), (.*), (.*)")]
        [When(@"I enter the following search weighing: (.*), (.*), (.*), (.*), (.*)")]
        public void GivenIEnterTheFollowingSearchWeighing(string name, string description, string keywords, string text, string custproperties)
        {
            SupportPoint.AdminPage.fillIn(name, description, keywords, text, custproperties);
        }

        [Given(@"I select the Display checkboxes")]
        [Then(@"I select the Display checkboxes")]
        [When(@"I select the Display checkboxes")]
        public void GivenISelectTheFollowingCheckboxes()
        {
            SupportPoint.AdminPage.setDisplay();
        }

    }
}
