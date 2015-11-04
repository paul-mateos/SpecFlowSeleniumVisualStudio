using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author
{
    [Binding]
    public sealed class RoleSelector_Steps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I Click on the Add roles Button")]
        [When(@"I Click on the Add roles Button")]
        [Then(@"I Click on the Add roles Button")]
        public void WhenIClickOnTheAddRolesButton()
        {
            SupportPoint.RoleSelectorPage.ClickAddRoleButton();
        }


        [Given(@"the Role Selector is opened")]
        [When(@"the Role Selector is opened")]
        [Then(@"the Role Selector is opened")]
        public void TheRoleSelectorIsOpened()
        {
            SupportPoint.RoleSelectorPage.ConfirmRoleSelector();
        }

        [Given(@"I search for role for (.*)")]
        [When(@"I search for role for (.*)")]
        [Then(@"I search for role for (.*)")]
        public void WhenISearchForRoleByFindByForSearchText(String searchText)
        {
            if (ScenarioContext.Current.ContainsKey("SearchBy"))
            {
                ScenarioContext.Current.Set(searchText, "SearchBy");
            }
            else
            {
                ScenarioContext.Current.Add("SearchBy", searchText);
            }
            SupportPoint.RoleSelectorPage.searchRole(searchText);
        }

        [Given(@"I select the record (.*) using column (.*) from the Role Selector table")]
        [When(@"I select the record (.*) using column (.*) from the Role Selector table")]
        [Then(@"I select the record (.*) using column (.*) from the Role Selector table")]
        public void IselecttherecordfromtheRoleSelectortable(string searchValue, string colName)
        {
            SupportPoint.RoleSelectorPage.ClickSelectorRecord(colName, searchValue);

        }

       
    }
}
