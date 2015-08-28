using SP_Automation.Tests;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject
{
    [Binding]
    public class DocumentManagement_PermissionsSteps
    {
        [Given(@"I navigate to the permissions page")]
        public void GivenINavigateToThePermissionsPage()
        {
            SupportPoint.DetailsActions.Permissions();
        }

        [When(@"I select the Edit button")]
        public void WhenISelectTheEditButton()
        {
            SupportPoint.DetailsActions.Edit();
        }

        [Then(@"I verify the Edit button isn't Visible")]
        public void ThenIVerifyTheEditButtonIsnTVisible()
        {
            SupportPoint.SPManagerDetailsActionsPage.NoEdit();
        }

        [Given(@"I select the (.*) button")]
        public void WhenISelectTheAddRoleToReadersButton(string newPermission)
        {
            Thread.Sleep(4000);
            SupportPoint.PermissionsPage.clickPermissionBtn(newPermission);
        }

        [Then(@"the Role Selector is opened")]
        public void ThenTheRoleSelectorIsOpened()
        {
            SupportPoint.RoleSelectorPage.ConfirmRoleSelector();
        }
        [Then(@"I can search for (.*)")]
        public void ThenICanSearchFor(string searchName)
        {
            SupportPoint.RoleSelectorPage.searchRole(searchName);
        }

        [Then(@"the search should return the (.*)")]
        public void ThenTheSearchShouldReturnTheAuthors(string searchName)
        {
            SupportPoint.RoleSelectorPage.confirmFoundRole(searchName);
        }


        [Then(@"I can select the (.*)")]
        public void ThenICanSelectTheAuthors(string searchName)
        {
         //   SupportPoint.RoleSelectorPage.selectRole(searchName);
        }


        [Then(@"the role is added to the document (.*) table")]
        public void ThenTheRoleIsAddedToTheDocumentRoleReadersTable(string newRole)
        {
          //  ScenarioContext.Current.Pending();
        }


    }
}
