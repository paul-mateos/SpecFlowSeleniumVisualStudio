using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.SP_Author.RoleManagement
{
    [Binding]
    public class RoleManagement_Steps : Steps
    {
        [Given(@"I enter the random role Name (.*)")]
        [When(@"I enter the random role Name (.*)")]
        [Then(@"I enter the random role Name (.*)")]
        public void IEnterTheRandomRoleName(string roleName)
        {
            string newName = SupportPoint.SPManagerDetailsActionsPage.SetRandomName(roleName);

            //Add feature content if it exists
            if (ScenarioContext.Current.ContainsKey("RoleName"))
            {
                ScenarioContext.Current.Set(newName, "RoleName");
            }
            else
            {
                ScenarioContext.Current.Add("RoleName", newName);
            }
        }

        [Given(@"I confirm the role Name")]
        [When(@"I confirm the role Name")]
        [Then(@"I confirm the role Name")]
        public void ThenIConfirmTheRoleName()
        {
            string roleName = ScenarioContext.Current.Get<string>("RoleName");
            SupportPoint.SPManagerDetailsActionsPage.ConfirmName(roleName);
        }

        [Given(@"I enter the role Description (.*)")]
        [When(@"I enter the role Description (.*)")]
        [Then(@"I enter the role Description (.*)")]
        public void IEnterTheRoleDescription(string roleDescription)
        {
            string newName = SupportPoint.SPManagerDetailsActionsPage.SetDescription(roleDescription);

            //Add feature content if it exists
            if (ScenarioContext.Current.ContainsKey("RoleDescription"))
            {
                ScenarioContext.Current.Set(newName, "RoleDescription");
            }
            else
            {
                ScenarioContext.Current.Add("RoleDescription", newName);
            }
        }

        [Given(@"I confirm the role Description")]
        [When(@"I confirm the role Description")]
        [Then(@"I confirm the role Description")]
        public void ThenIConfirmTheRoleDescription()
        {
            string roleDescription = ScenarioContext.Current.Get<string>("RoleDescription");
            SupportPoint.SPManagerDetailsActionsPage.ConfirmDescription(roleDescription);
        }

        [Given(@"I select the record (.*) using column (.*) from the Role table")]
        [When(@"I select the record (.*) using column (.*) from the Role table")]
        [Then(@"I select the record (.*) using column (.*) from the Role table")]
        public void IselecttherecordfromtheRoletable(string searchValue, string colName)
        {
            SupportPoint.RoleManagementPage.ClickRecord(colName, searchValue);

        }
    }
}
