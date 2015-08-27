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
        [Then(@"I can select a role")]
        public void ThenICanSelectARole()
        {
          //  ScenarioContext.Current.Pending();
        }

        [Then(@"the rold is added to the read document table")]
        public void ThenTheRoldIsAddedToTheReadDocumentTable()
        {
         //   ScenarioContext.Current.Pending();
        }

    }
}
