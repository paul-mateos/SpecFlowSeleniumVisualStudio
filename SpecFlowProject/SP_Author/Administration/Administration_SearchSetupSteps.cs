using SeleniumProject.Tests;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class Administration_SearchSetupSteps
    {

        [Given(@"I select (.*) using the column (.*) from the Admin table")]
        [When(@"I select (.*) using the column (.*) from the Admin table")]
        [Then(@"I select (.*) using the column (.*) from the Admin table")]
        public void GivenISelectSearchSetupUsingTheColumnNameFromTheAdminTable(string searchValue, string colName)
        {
            SupportPoint.AdminPage.ClickRecord(colName, searchValue);
        }

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
